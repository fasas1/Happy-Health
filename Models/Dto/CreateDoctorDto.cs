using System.ComponentModel.DataAnnotations;

namespace Happy_Health.Models.Dto
{
    public class CreateDoctorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specialty { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
