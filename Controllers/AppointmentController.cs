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
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _dbAppointment;
        private readonly APIResponse _response;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentRepository dbAppointment, IMapper mapper)
        {
            _dbAppointment = dbAppointment;
            _response = new APIResponse();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAppointments()
        {
            try
            {
                var appointmentList = await _dbAppointment.GetAllAsync(includeProperties: "Patient,Doctor");
                _response.Result = _mapper.Map<List<AppointmentDto>>(appointmentList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<APIResponse>> GetAppointment(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string> { "Invalid ID. ID cannot be 0." };
                    return BadRequest(_response);
                }

                var appointment = await _dbAppointment.GetAsync(x => x.Id == id, includeProperties: "Doctor,Patient");

                if (appointment == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string> { $"No appointment found with ID {id}." };
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<AppointmentDto>(appointment);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }


        [HttpPost]
        public async Task<ActionResult<APIResponse>> CreateAppointment([FromBody] CreateAppointmentDto appointmentCreated)
        {
            try
            {
                if (appointmentCreated == null)
                {
                    _response.IsSuccess = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var appointment = _mapper.Map<Appointment>(appointmentCreated);

                await _dbAppointment.CreateAsync(appointment);

                _response.Result = _mapper.Map<AppointmentDto>(appointment);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;
                return CreatedAtAction(nameof(GetAppointment), new { id = appointment.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _response);
            }
        }


    }
}
