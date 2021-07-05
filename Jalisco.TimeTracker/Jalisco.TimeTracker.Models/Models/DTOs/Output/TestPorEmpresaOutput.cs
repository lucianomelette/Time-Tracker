using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jalisco.TimeTracker.Models.Models.DTOs.Output
{
    public class TestPorEmpresaOutput
    {
        public double TiempoQueryApiTraductora { get; set; }
        public double TiempoProcesoApiTraductora { get; set; }
        public DateTime HoraRequestApiTraductora { get; set; }
        public double TiempoResponseApiTraductora { get; set; }
        public double RegistrosProcesados { get; set; }
        public string UrlApiTraductora { get; set; }
        public string Dsn { get; set; }
    }
}
