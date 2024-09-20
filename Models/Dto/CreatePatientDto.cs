using System.ComponentModel.DataAnnotations;

namespace Happy_Health.Models.Dto
{
    public class CreatePatientDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
