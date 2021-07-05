using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Jalisco.TimeTracker.API.Domain.Services;
using Jalisco.TimeTracker.Models.Models.DTOs.Input;
using Jalisco.TimeTracker.Models.Models.DTOs.Output;
using System.Diagnostics;
using System.Collections.Generic;

namespace Jalisco.TimeTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TimeTrackerTestsController : ControllerBase
    {
        private readonly ITimeTrackerTestsService _timeTrackerTestsService;
        private readonly IMapper _mapper;

        public TimeTrackerTestsController(ITimeTrackerTestsService timeTrackerTestsService, IMapper mapper)
        {
            _timeTrackerTestsService = timeTrackerTestsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("TestUnaEmpresa")]
        public async Task<ActionResult<TestResultOutput>> TestUnaEmpresa()
        {
            try {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var testResult = await _timeTrackerTestsService.TestUnaEmpresa().ConfigureAwait(false);
                stopwatch.Stop();
                testResult.TiempoTotalBackend = stopwatch.Elapsed.TotalSeconds;
                return Ok(testResult);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("TestUnaEmpresaOleDb")]
        public async Task<ActionResult<TestResultOutput>> TestUnaEmpresaOleDb()
        {
            try {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var testResult = await _timeTrackerTestsService.TestUnaEmpresaOleDb().ConfigureAwait(false);
                stopwatch.Stop();
                testResult.TiempoTotalBackend = stopwatch.Elapsed.TotalSeconds;
                return Ok(testResult);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("TestListaEmpresasAsync")]
        public async Task<ActionResult<TestResultOutput>> TestListaEmpresasAsync()
        {
            try {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var testResults = await _timeTrackerTestsService.TestListaEmpresasAsync().ConfigureAwait(false);
                stopwatch.Stop();
                testResults.TiempoTotalBackend = stopwatch.Elapsed.TotalSeconds;
                return Ok(testResults);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("TestListaEmpresasParalelo")]
        public async Task<ActionResult<TestResultOutput>> TestListaEmpresasParalelo()
        {
            try {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                var testResults = await _timeTrackerTestsService.TestListaEmpresasParalelo().ConfigureAwait(false);
                stopwatch.Stop();
                testResults.TiempoTotalBackend = stopwatch.Elapsed.TotalSeconds;
                return Ok(testResults);
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}