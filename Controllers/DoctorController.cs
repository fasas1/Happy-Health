using AutoMapper;
using Azure;
using Happy_Health.Models;
using Happy_Health.Models.Dto;
using Happy_Health.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Happy_Health.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _dbDoctor;
        private readonly IMapper _mapper;
        private readonly APIResponse _response;

        public DoctorController(IDoctorRepository dbDoctor, IMapper mapper)
        {
            _dbDoctor = dbDoctor;
            _mapper = mapper;
            _response = new APIResponse();
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetDoctors()
        {
            try
            {
                var doctorList = await _dbDoctor.GetAllAsync();
                _response.Result = _mapper.Map<List<DoctorDto>>(doctorList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = _response.ErrorMessages = new List<string> { ex.Message };

            }
            return _response;
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<APIResponse>> GetDoctor(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Doctor model = await _dbDoctor.GetAsync(x => x.DoctorId == id);
                if (model == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<DoctorDto>(model);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }
        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateDoctor([FromBody] CreateDoctorDto createdDto)
        {
            try
            {
                if (createdDto == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                Doctor model = _mapper.Map<Doctor>(createdDto);
                await _dbDoctor.CreateAsync(model);
                await _dbDoctor.SaveAsync();

                _response.Result = _mapper.Map<DoctorDto>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<APIResponse>> UpdateDoctor(int id, [FromBody] UpdateDoctorDto updatedDto)
        {
            try
            {
                if (updatedDto == null || id != updatedDto.DoctorId)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var doctorFromDb = await _dbDoctor.GetAsync(x => x.DoctorId == id);
                if (doctorFromDb == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _mapper.Map(updatedDto, doctorFromDb);

                await _dbDoctor.UpdateAsync(doctorFromDb);

                _response.Result = _mapper.Map<DoctorDto>(doctorFromDb);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = _response.ErrorMessages = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<APIResponse>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var model = await _dbDoctor.GetAsync(x => x.DoctorId == id);
                if (model == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                await _dbDoctor.RemoveAsync(model);
                _dbDoctor.SaveAsync();

                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }

            catch (Exception ex)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = _response.ErrorMessages = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
            }
            return _response;
        }        

    }
}
