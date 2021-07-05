using System.ComponentModel.DataAnnotations;

namespace Jalisco.TimeTracker.Models.Models.DTOs.Input
{
    public class ImpuestoInput
    {
        [Required]
        public string AlicuotaIvaId { get; set; }
        [Required]
        public double BaseImponible { get; set; }
        [Required]
        public double Porcentaje { get; set; }
        [Required]
        public double ImporteIva { get; set; }
    }
}
