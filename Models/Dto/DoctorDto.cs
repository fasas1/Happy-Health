using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Happy_Health.Models.Dto
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specialty { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }
}
