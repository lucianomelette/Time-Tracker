using GaussFramework.API.Helpers;
using GaussFramework.API.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Jalisco.TimeTracker.API.Persistance.Context;
using Jalisco.TimeTracker.Models.Models.Configuracion;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;
using Jalisco.TimeTracker.Models.Models.DTOs.Output;
using Jalisco.TimeTracker.Models.Models.Entidades;
using Jalisco.TimeTracker.Models.Models.Entidades.Auxiliares;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Jalisco.TimeTracker.API.Persistance.Repositories
{
    public class BaseRepository
    {
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly ApplicationDbContext _context;

        private int EmpresaId {
            get { return Convert.ToInt32(_contextAccessor.HttpContext.Request.Headers["Id-Empresa"]); }
        }
        private int[] EmpresaIdList {
            get {
                return _contextAccessor.HttpContext.Request.Headers["Lista-Id-Empresas"]
                    .ToString()
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray();
            }
        }

        protected Empresa Empresa {
            get {
                var empresa = _context.Empresas.FirstOrDefault(x => x.Id == EmpresaId);
                if (empresa == null)
                    throw new KeyNotFoundException($"{EmpresaId} - Empresa inexistente");
                return empresa;
            }
        }

        protected List<Empresa> Empresas {
            get {
                List<Empresa> empresas = new List<Empresa>();
                foreach(int empresaId in EmpresaIdList)
                {
                    var empresa = _context.Empresas.FirstOrDefault(x => x.Id == empresaId);
                    if (empresa == null)
                        throw new KeyNotFoundException($"{empresaId} - Empresa inexistente");
                    empresas.Add(empresa);
                }
                return empresas;
            }
        }

        private IConfiguration _configuration { get; }

        public BaseRepository(
            IHttpContextAccessor contextAccessor,
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _configuration = configuration;
        }

        protected async Task<TestPorEmpresaOutput> EjecutarUnitario(string query)
        {
            return await TestPorEmpresa(Empresa, query);
        }

        protected async Task<TestPorEmpresaOutput> EjecutarUnitarioOleDb(string query)
        {
            return await TestPorEmpresaOleDb(query);
        }

        protected async Task<List<TestPorEmpresaOutput>> EjecutarMultiempresaAsync(string query)
        {
            List<TestPorEmpresaOutput> tests = new List<TestPorEmpresaOutput>();

            foreach(Empresa empresa in Empresas)
            {
                var test = await TestPorEmpresa(empresa, query);
                tests.Add(test);
            }

            return tests;
        }

        protected async Task<TestPorEmpresaOutput[]> EjecutarMultiempresaParalelo(string query)
        {
            var tasks = Empresas.Select(empresa => TestPorEmpresa(empresa, query));
            return await Task.WhenAll(tasks);
        }

        private async Task<TestPorEmpresaOutput> TestPorEmpresa(Empresa empresa, string query)
        {
            var queryExecutorUrl = $"{empresa.QueryExecutorUrl}/QueryExecutor/Unitario";

            SQLRequest request = new SQLRequest()
            {
                Query = query,
                Parametros = new List<(string, object, OdbcType)>(),
                Dsns = new List<string> { empresa.DSN }
            };
            
            var horaIni = DateTime.Now;            
            HTTPResponse response = await HTTPHelper.PostAsync(queryExecutorUrl, JsonConvert.SerializeObject(request));

            var cantRecords = DeserializarHTTPResponse<Numero>(response)?.SingleOrDefault().Valor ?? 0;

            var test = new TestPorEmpresaOutput();
            test.TiempoQueryApiTraductora = response.TiempoQuery.TotalSeconds;
            test.TiempoProcesoApiTraductora = response.TiempoProceso.TotalSeconds;
            test.HoraRequestApiTraductora = horaIni;
            test.TiempoResponseApiTraductora = response.TiempoRequest.TotalSeconds;
            test.RegistrosProcesados = cantRecords;
            test.Dsn = empresa.DSN;
            test.UrlApiTraductora = queryExecutorUrl;

            return test;
        }

        private async Task<TestPorEmpresaOutput> TestPorEmpresaOleDb(string query)
        {
            var providerName =  _configuration["OleDbStrings:ProviderName"];
            var dbcPath =  _configuration["OleDbStrings:DbcPath"];

            using (var con = new OleDbConnection($"Provider={providerName} ;Data Source={dbcPath}"))
            {
                try
                {
                    var horaIni = DateTime.Now;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    await con.OpenAsync();

                    using (var cmd = new OleDbCommand(query, con))
                    {
                        // Nonquery method is good when there is nothing to return
                        var reader = await cmd.ExecuteReaderAsync();

                        var cantRecords = 0;
                        while (await reader.ReadAsync())
                        {
                            cantRecords = reader.GetInt32(0);
                        }
                        stopwatch.Stop();

                        var test = new TestPorEmpresaOutput();
                        test.TiempoQueryApiTraductora = 0;
                        test.TiempoProcesoApiTraductora = 0;
                        test.HoraRequestApiTraductora = horaIni;
                        test.TiempoResponseApiTraductora = stopwatch.Elapsed.TotalSeconds;
                        test.RegistrosProcesados = cantRecords;
                        test.Dsn = null;
                        test.UrlApiTraductora = dbcPath;

                        return test;
                    }
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }

        protected async Task<HTTPResponse> EjecutarTransaccion(List<SQLRequest> instruccionesTrx)
        {
            var queryExecutorUrl = $"{Empresa.QueryExecutorUrl}/QueryExecutor/EnTransaction";

            return await HTTPHelper.PostAsync(queryExecutorUrl, JsonConvert.SerializeObject(instruccionesTrx));
        }

        protected List<T> DeserializarHTTPResponse<T>(HTTPResponse response) where T : class
        {
            if (response.Success) {
                try {
                    return JsonConvert.DeserializeObject<List<T>>(response.Response.ToString());
                }
                catch (Exception) {
                    return null;
                }
            }
            else {
                if (response.NotFound)
                    throw new KeyNotFoundException(response.Error ?? response.Message);
                else
                    throw new ArgumentException(response.Error ?? response.Message);
            }
        }

        protected async Task<string> CompletarColumnasNeutras(string nombreTabla, List<OdbcParameter> parametros)
        {
            return await QueryBuilderHelper.QueryAgregarRegistroNeutroAsync(
                Empresa.QueryExecutorUrl, new List<string> { Empresa.DSN }, nombreTabla, parametros);       
        }

        protected void AgregarInstruccionesTransaccion(List<SQLRequest> instruccionesTrx, List<string> queries)
        {
            foreach(var query in queries)
            {
                AgregarInstruccionTransaccion(instruccionesTrx, query);
            }
        }

        protected void AgregarInstruccionTransaccion(List<SQLRequest> instruccionesTrx, string query)
        {
            instruccionesTrx.Add(new SQLRequest()
            {
                Query = query,
                Parametros = new List<(string, Object, System.Data.Odbc.OdbcType)>(),
                Dsns = new List<string> { Empresa.DSN }
            });
        }
    }
}
