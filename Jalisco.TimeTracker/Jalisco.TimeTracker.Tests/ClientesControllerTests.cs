
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jalisco.TimeTracker.API.Controllers;
using Jalisco.TimeTracker.API.Persistance.Repositories;
using Jalisco.TimeTracker.API.Services;
using Jalisco.TimeTracker.Models.Models.DTOs.Output;
using Jalisco.TimeTracker.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jalisco.TimeTracker.Tests
{
    [TestClass]
    public class ClientesControllerTests
    {
        //private EntidadesService _entidadesService;
        //private EntidadesRepository _entidadesRepository;
        //private ClientesService _clientesService;
        //private ClientesRepository _clientesRepository;
        //private IMapper _mapper;

        //public ClientesControllerTests()
        //{
        //    _entidadesRepository = new EntidadesRepository();
        //    _entidadesService = new EntidadesService(_entidadesRepository);
        //    _clientesRepository = new ClientesRepository(); 
        //    _clientesService = new ClientesService(_clientesRepository, _entidadesService);
        //    _mapper = MapperGenerator.ClientesMapper();
        //}

        //[TestMethod]
        //public async Task Get_sExitoso_ClientesRetorna200()
        //{
        //    //Act
        //    var data = await new ClientesController(_clientesService, _mapper).ClientesAsync();

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<ClienteOutput>));

        //}

        //[TestMethod]
        //public async Task Get_Exitoso_UnSoloClienteRetorna200()
        //{
        //    //Act
        //    var data = await new ClientesController(_clientesService, _mapper).ClienteAsync("01052");

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<ClienteOutput>));

        //}
        //[TestMethod]
        //public async Task Get_Fallido_UnSoloClienteRetorna404()
        //{
        //    //Act
        //    var data = await new ClientesController(_clientesService, _mapper).ClienteAsync("MARIA");

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<ClienteOutput>));

        //}

        //[TestMethod]
        //public async Task Get_Exitoso_CuentaCorrienteRetorna200()
        //{
        //    //Act
        //    var data = await new ClientesController(_clientesService, _mapper).CuentaCorrienteAsync("01052");

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<CuentaCorrienteOutput>));

        //}
        //[TestMethod]
        //public async Task Get_Exitoso_CuentaCorrienteMonedaEspecificadaRetorna200()
        //{
        //    //Act
        //    var data = await new ClientesController(_clientesService, _mapper).CuentaCorrienteAsync("01052", "DOL");

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<CuentaCorrienteOutput>));

        //}
        //[TestMethod]
        //public async Task Get_Fallido_CuentaCorrienteIdClienteInexistenteRetorna404()
        //{
        //    //Act
        //    var data = await new ClientesController(_clientesService, _mapper).CuentaCorrienteAsync("MARIA");

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<CuentaCorrienteOutput>));
        //    Assert.IsInstanceOfType(data.Result, typeof(NotFoundObjectResult));
        //}

        //[TestMethod]
        //public async Task Get_Fallido_CuentaCorrienteIdMonedaInexistenteRetorna404()
        //{
        //    //Act
        //    var data = await new ClientesController(_clientesService, _mapper).CuentaCorrienteAsync("01052", "LIB");

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<CuentaCorrienteOutput>));
        //    Assert.IsInstanceOfType(data.Result, typeof(NotFoundObjectResult));

        //}
    }
}
