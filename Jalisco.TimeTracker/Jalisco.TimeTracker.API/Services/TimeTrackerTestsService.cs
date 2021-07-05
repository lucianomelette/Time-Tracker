using Microsoft.AspNetCore.Http;
using Jalisco.TimeTracker.API.Domain.Repositories;
using Jalisco.TimeTracker.API.Domain.Services;
using Jalisco.TimeTracker.Models.Models.Configuracion;
using Jalisco.TimeTracker.Models.Models.DTOs.Output;
using Jalisco.TimeTracker.Models.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jalisco.TimeTracker.API.Services
{
    public class TimeTrackerTestsService : ITimeTrackerTestsService
    {
        private readonly ITimeTrackerTestsRepository _timeTrackerTestsRepository;

        public TimeTrackerTestsService(ITimeTrackerTestsRepository timeTrackerTestsRepository)
        {
            _timeTrackerTestsRepository = timeTrackerTestsRepository;
        }

        public async Task<TestResultOutput> TestUnaEmpresa()
        {
            return await _timeTrackerTestsRepository.TestUnaEmpresa().ConfigureAwait(false);
        }

        public async Task<TestResultOutput> TestUnaEmpresaOleDb()
        {
            return await _timeTrackerTestsRepository.TestUnaEmpresaOleDb().ConfigureAwait(false);
        }

        public async Task<TestResultOutput> TestListaEmpresasAsync()
        {
            return await _timeTrackerTestsRepository.TestListaEmpresasAsync().ConfigureAwait(false);
        }

        public async Task<TestResultOutput> TestListaEmpresasParalelo()
        {
            return await _timeTrackerTestsRepository.TestListaEmpresasParalelo().ConfigureAwait(false);
        }
    }
}
