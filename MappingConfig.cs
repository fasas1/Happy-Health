using AutoMapper;
using Happy_Health.Models;
using Happy_Health.Models.Dto;

namespace Happy_Health
{
    public class MappingConfig 
    {
        public static MapperConfiguration RegisterMaps()
        {
             var mappingConfig = new MapperConfiguration(config =>
             {
                 config.CreateMap<PatientDto, Patient>().ReverseMap();
                 config.CreateMap<CreatePatientDto, Patient>().ReverseMap();
                 config.CreateMap<UpdatePatientDto, Patient>().ReverseMap();

                 config.CreateMap<DoctorDto, Doctor>().ReverseMap();
                 config.CreateMap<CreateDoctorDto, Doctor>().ReverseMap();
                 config.CreateMap<UpdateDoctorDto, Doctor>().ReverseMap();

                 config.CreateMap<AppointmentDto, Appointment>().ReverseMap();
                 config.CreateMap<CreateAppointmentDto, Appointment>().ReverseMap();
             });
            return mappingConfig;
        }
    }
}
