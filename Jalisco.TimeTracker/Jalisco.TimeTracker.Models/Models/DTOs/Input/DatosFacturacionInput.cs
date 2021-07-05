using System.ComponentModel.DataAnnotations;

namespace Jalisco.TimeTracker.Models.Models.DTOs.Input
{
    public class DatosFacturacionInput
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string CodPostal { get; set; }
        [Required]
        public string Localidad { get; set; }
        [Required]
        public string CondicionPagoId { get; set; }
        [Required]
        public string ProvinciaId { get; set; }
        [Required]
        public string ExpresoId { get; set; }
        [Required]
        public string ZonaId { get; set; }
        [Required]
        public string ListaPrecioId { get; set; }
    }
}
