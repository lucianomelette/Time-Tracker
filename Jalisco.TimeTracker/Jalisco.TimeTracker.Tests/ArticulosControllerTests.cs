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
    public class ArticulosControllerTests
    {
        //private ArticulosService _articulosService;
        //private ArticulosRepository _articulosRepository;
        //private IMapper _mapper;

        //public ArticulosControllerTests()
        //{
        //    _articulosRepository = new ArticulosRepository(); 
        //    _articulosService = new ArticulosService(_articulosRepository);
        //    _mapper = MapperGenerator.ArticulosMapper(); 
        //}

        //[TestMethod]
        //public async Task Get_Exitoso_ListaRetorna200()
        //{
        //    List<String> depositos = new List<string>();
        //    depositos.Add("001");
        //    depositos.Add("RES"); 
        //    //Act
        //    var data = await new ArticulosController(_articulosService, _mapper).ArticulosAsync(depositos, "001") ;

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<ArticuloOutput>));
        //}

        //[TestMethod]
        //public async Task Get_Fallido_DepositosVaciosRetorna400()
        //{

        //    //Act
        //    var data = await new ArticulosController(_articulosService, _mapper).ArticulosAsync(new List<string>(), "001");

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(BadRequestObjectResult));
        //}

        //[TestMethod]
        //public async Task Get_Fallido_ListaPreciosVaciaRetorna400()
        //{
        //    List<String> depositos = new List<string>();
        //    depositos.Add("001");
        //    depositos.Add("RES");
        //    //Act
        //    var data = await new ArticulosController(_articulosService, _mapper).ArticulosAsync(new List<string>(), "");

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(BadRequestObjectResult));
        //}

        //[TestMethod]
        //public async Task Get_Exitoso_ParticularRetorna200()
        //{
            
        //    //Act
        //    var data = await new ArticulosController(_articulosService, _mapper).ArticuloAsync("00010");

        //    //Assert
        //    Assert.IsInstanceOfType(data, typeof(ActionResult<ArticuloOutput>));
        //}

        //[TestMethod]
        //public async Task Get_Fallido_ArticuloRetorna404()
        //{

        //    //Act
        //    var data = await new ArticulosController(_articulosService, _mapper).ArticuloAsync("00000");

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(NotFoundObjectResult));
        //}

        //[TestMethod]
        //public async Task Get_Exitoso_ConOffsetRetorna200()
        //{
        //    ArticuloOutput output = new ArticuloOutput()
        //    {
        //        IdArticulo = "01013          ",
        //        AlicuotaIva = 21,
        //        CodigoBarras = "                         ",
        //        Costo = 2.19231,
        //        Imagenes = new List<string>(),
        //        Marca = "IMPORTADOS                    ",
        //        MonedaCosto = "Pesos                         ",
        //        MonedaPrecio = "Pesos                         ",
        //        Nombre = "ADAPTADOR SWITCHING AUTO 12Vcc-5Vcc 2A USB        ",
        //        Precio = 2.1923,
        //        Rubro = "FUENTE DE ALIMENTACION NACIONAL.",
        //        Stock = 168,
        //        Subrubro = "FUENTES SWITCHING             "
        //    };
        //    List<String> depositos = new List<string>();
        //    depositos.Add("001");
        //    depositos.Add("RES");
        //    //Act
        //    var data = await new ArticulosController(_articulosService, _mapper).ArticulosAsync(depositos, "001", 50, "00248");

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(ActionResult<ArticuloOutput>));
        //}


    }
}
