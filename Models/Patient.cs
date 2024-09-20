using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Happy_Health.Models
{
    public class Patient
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int  Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        // Navigation property for related appointments
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
