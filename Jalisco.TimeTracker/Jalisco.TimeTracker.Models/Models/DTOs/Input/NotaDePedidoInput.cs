using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jalisco.TimeTracker.Models.Models.DTOs.Input
{
    public class NotaDePedidoInput
    {
        [Required] 
        public string UsuarioId { get; set; }
        [Required]
        public string PlataformaId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrega { get; set; }
        [Required]
        public string ClienteId { get; set; }
        [Required]
        public DatosFacturacionInput DatosFacturacion { get; set; }
        [Required]
        public double PorcBonif1 { get; set; }
        [Required]
        public double PorcBonif2 { get; set; }
        [Required]
        public double ImpBonif1 { get; set; }
        [Required]
        public double ImpBonif2 { get; set; }
        [Required]
        public double SubtotalSinBonif { get; set; }
        [Required]
        public double SubtotalConBonif { get; set; }
        [Required]
        public string Leyenda1 { get; set; }
        [Required]
        public string Leyenda2 { get; set; }
        [Required]
        public string Leyenda3 { get; set; }
        [Required]
        public string Leyenda4 { get; set; }
        [Required]
        public string Leyenda5 { get; set; }
        [Required]
        public string Leyenda6 { get; set; }
        [Required]
        public string Leyenda7 { get; set; }
        [Required]
        public string Leyenda8 { get; set; }
        public List<ImpuestoInput> Impuestos { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public List<ArticuloInput> Detalle { get; set; }
        [Required]
        public ContactoInput Contacto { get; set; }
    }
}
