using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happy_Health.Models
{
    public class Doctor
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DoctorId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Specialty { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        // Navigation property for related appointments
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
