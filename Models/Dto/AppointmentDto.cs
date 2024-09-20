using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Happy_Health.Models.Dto
{
    public class AppointmentDto
    {
       // public int Id { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
