
using System.ComponentModel.DataAnnotations.Schema;

namespace Jalisco.TimeTracker.Models.Models.Configuracion
{
    public class ConfigNotaDePedido
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string IdPlataforma { get; set; }
        public string IdComprobante { get; set; }
        public Empresa Empresa { get; set; }
    }
}
