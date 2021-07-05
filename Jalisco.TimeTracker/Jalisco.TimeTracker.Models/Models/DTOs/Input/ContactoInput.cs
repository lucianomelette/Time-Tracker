using System.ComponentModel.DataAnnotations;

namespace Jalisco.TimeTracker.Models.Models.DTOs.Input
{
    public class ContactoInput
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
