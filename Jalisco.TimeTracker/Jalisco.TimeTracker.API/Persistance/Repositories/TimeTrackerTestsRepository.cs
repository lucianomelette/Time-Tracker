using GaussFramework.API.Models;
using Microsoft.AspNetCore.Http;
using Jalisco.TimeTracker.API.Domain.Repositories;
using Jalisco.TimeTracker.API.Persistance.Context;
using Jalisco.TimeTracker.Models.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Threading.Tasks;
using Jalisco.TimeTracker.Models.Models.DTOs.Output;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Jalisco.TimeTracker.API.Persistance.Repositories
{
    public class TimeTrackerTestsRepository : BaseRepository, ITimeTrackerTestsRepository
    {
        private string _query =
                "SELECT " +
                    "COUNT(*) as Valor " +
                    // "YEAR(vnt_cabecera.fecha) as anio, " +
                    // "MONTH(vnt_cabecera.fecha) as mes, " +
                    // "SUM(iif(vnt_cabecera.suma, 1, -1) * vnt_cabecera.baseImponible * iif(Alltrim(vnt_cabecera.id_mon_impresion) = 'PES', 1, vnt_cabecera.cot_mon_impresion / cotizacomprobantes.cotizacion)) as monto " +
                "FROM " +
                    "vnt_cabecera " +
                    "INNER JOIN vnt_docu ON vnt_cabecera.id_comproba = vnt_docu.id_comproba " +
                    "INNER JOIN cotizaComprobantes ON vnt_cabecera.id_sucursal+vnt_cabecera.id_sistema+vnt_cabecera.id_comproba+str(vnt_cabecera.nro_referencia,10)+'PES' = cotizacomprobantes.id_sucursal+cotizacomprobantes.id_sistema+cotizacomprobantes.id_comproba+str(cotizacomprobantes.nro_referencia,10)+cotizacomprobantes.id_moneda " +
                    "INNER JOIN clientes on vnt_cabecera.id_cliente = clientes.id_cliente " +
                "WHERE " +
                    "!vnt_cabecera.cobranza " +
                    "AND vnt_cabecera.remunerativo " +
                    "AND vnt_docu.valorizado " +
                    "AND !(INLIST(vnt_docu.id_comproba, 'AZD', 'NC1', 'NCR', 'NDO', 'NCC', 'NCA', 'M50', 'M52', 'M53', 'N50', 'N52', 'N53', 'NBB', 'NCD', 'NDA', 'NRA', 'NDB', 'NRB', 'NCO') " +
                        "OR INLIST(vnt_docu.id_comproba, 'FCO', 'LIQ', 'TFC', 'LIM', 'FSS', 'AZH', 'AJD', 'ADT', 'AJH', 'AHT', 'CVO', 'NVO', 'F50', 'F52', 'F53', 'A50', 'A52', 'A53', 'B50', 'B52') " +
                        "OR INLIST(vnt_docu.id_comproba, 'B53', 'FBA', 'FOS', 'FIS', 'TAR', 'TNC')) " +
                    "AND !vnt_cabecera.anulado " +
                    "AND  vnt_Cabecera.fecha BETWEEN CTOD('05-01-2020') AND CTOD('05-31-2021') " +
                    "AND .T. " +
                    "AND .T. ";
                // "GROUP BY 1, 2 " +
                // "ORDER BY 1, 2 ";

        public TimeTrackerTestsRepository(
            IHttpContextAccessor contextAccessor,
            ApplicationDbContext context,
            IConfiguration configuration) : base(contextAccessor, context, configuration)
        {}

        public async Task<TestResultOutput> TestUnaEmpresa()
        {
            TestPorEmpresaOutput test = await EjecutarUnitario(_query).ConfigureAwait(false);

            TestResultOutput result = new TestResultOutput();
            result.Tests = new List<TestPorEmpresaOutput>();
            result.Tests.Add(test);
            result.Query = _query;

            return result;
        }

        public async Task<TestResultOutput> TestUnaEmpresaOleDb()
        {
            TestPorEmpresaOutput test = await EjecutarUnitarioOleDb(_query).ConfigureAwait(false);

            TestResultOutput result = new TestResultOutput();
            result.Tests = new List<TestPorEmpresaOutput>();
            result.Tests.Add(test);
            result.Query = _query;

            return result;
        }

        public async Task<TestResultOutput> TestListaEmpresasAsync()
        {
            List<TestPorEmpresaOutput> tests = await EjecutarMultiempresaAsync(_query).ConfigureAwait(false);

            TestResultOutput result = new TestResultOutput();
            result.Tests = tests;
            result.Query = _query;

            return result;
        }

        public async Task<TestResultOutput> TestListaEmpresasParalelo()
        {
            TestPorEmpresaOutput[] tests = await EjecutarMultiempresaParalelo(_query).ConfigureAwait(false);

            TestResultOutput result = new TestResultOutput();
            result.Tests = tests.OfType<TestPorEmpresaOutput>().ToList();
            result.Query = _query;

            return result;
        }
    }
}