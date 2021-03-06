using Jalisco.TimeTracker.Models.Models.DTOs.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jalisco.TimeTracker.API.Domain.Services
{
    public interface ITimeTrackerTestsService
    {
        Task<TestResultOutput> TestUnaEmpresa();
        Task<TestResultOutput> TestUnaEmpresaOleDb();
        Task<TestResultOutput> TestListaEmpresasAsync();
        Task<TestResultOutput> TestListaEmpresasParalelo();
    }
}
