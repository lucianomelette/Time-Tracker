
using System.Collections.Generic;

namespace Jalisco.TimeTracker.Models.Models.Configuracion
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EiffelId { get; set; }
        public int ClienteId { get; set; }
        public string QueryExecutorUrl { get; set; }
        public string DSN { get; set; }
        public List<ConfigNotaDePedido> ConfigNotasDePedido { get; set; }
    }
}
