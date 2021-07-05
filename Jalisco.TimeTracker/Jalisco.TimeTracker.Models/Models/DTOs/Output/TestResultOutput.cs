using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Jalisco.TimeTracker.Models.Models.DTOs.Output
{
    public class TestResultOutput
    {
        public List<TestPorEmpresaOutput> Tests { get; set; }
        public double TiempoTotalBackend { get; set; }
        public string Query { get; set; }
    }
}
