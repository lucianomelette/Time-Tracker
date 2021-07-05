using System.ComponentModel.DataAnnotations;

namespace Jalisco.TimeTracker.Models.Models.DTOs.Input
{
    public class ArticuloInput
    {
        [Required]
        public string ArticuloId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public double Cantidad { get; set; }        
        [Required]
        public double PrecioUnitarioSinBonif { get; set; }
        [Required]
        public double PrecioUnitarioConBonif { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public double PorcBonif { get; set; }
        [Required]
        public double PrecioLista { get; set; }
    }
}
