using AutoMapper;
using Happy_Health.Data;
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
    public class PatientController : ControllerBase
    {
        private readonly APIResponse _response;
        private readonly IPatientRepository _dbPatient;
        private IMapper _mapper;
        //private ApplicationDbContext _db;

        public PatientController(IPatientRepository dbPatient, IMapper mapper)
        {
            _dbPatient = dbPatient;
            _mapper = mapper;
            _response = new APIResponse();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetPatients()
        {
            try
            {
                 var patientList =  await _dbPatient.GetAllAsync();
                _response.Result = _mapper.Map<List<PatientDto>>(patientList); ;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages = new List<string> { ex.Message };
                }

                return _response;

            }
        }
        [HttpGet("{id:int}", Name = "GetPatient")]

        public async Task<ActionResult<APIResponse>> GetPatient(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }
                var obj = await _dbPatient.GetAsync(x => x.Id == id);
                if (obj == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                _response.Result = obj;
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return Ok(_response);
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreatePatient([FromBody] CreatePatientDto createPatientDto)
        {
            try
            {
                if (createPatientDto == null)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                Patient model = _mapper.Map<Patient>(createPatientDto);
                await _dbPatient.CreateAsync(model);
                await _dbPatient.SaveAsync();
                _response.Result = _mapper.Map<PatientDto>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetPatient", new { id = model.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<APIResponse>> UpdatePatient(int id, [FromBody] UpdatePatientDto updatePatientDto)
        {
            try
            {
                if (updatePatientDto == null || id != updatePatientDto.Id)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest(_response);
                }

                var patientFromDb = await _dbPatient.GetAsync(x => x.Id == id);
                if (patientFromDb == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }

                // Map the updated properties to the patientFromDb object
                _mapper.Map(updatePatientDto, patientFromDb);

                await _dbPatient.UpdateAsync(patientFromDb);
                //_db.SaveChanges();

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };

            }
            return _response;
        }

        [HttpDelete]
        public async Task<ActionResult<APIResponse>> DeletePatient(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                var patientFromDb = await _dbPatient.GetAsync(x => x.Id == id);
                if (patientFromDb == null)
                {
               // _response.StatusCode = HttpStatusCode.NoContent;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.IsSuccess = false;
                    return BadRequest();
                }
                await _dbPatient.RemoveAsync(patientFromDb);
                // _db.SaveChanges();
                _response.IsSuccess = true;
                return Ok();

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

    }
}
    

