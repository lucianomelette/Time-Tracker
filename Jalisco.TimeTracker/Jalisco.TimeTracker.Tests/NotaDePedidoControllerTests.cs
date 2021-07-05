using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jalisco.TimeTracker.API.Controllers;
using Jalisco.TimeTracker.API.Domain.Repositories;
using Jalisco.TimeTracker.API.Domain.Services;
using Jalisco.TimeTracker.API.Persistance.Repositories;
using Jalisco.TimeTracker.API.Services;
using Jalisco.TimeTracker.Models.Models.DTOs.Input;
using Jalisco.TimeTracker.Models.Models.DTOs.Output;
using Jalisco.TimeTracker.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jalisco.TimeTracker.Tests
{
    [TestClass]
    public class NotaDePedidoControllerTests
    {
        //private EntidadesService _entidadesService;
        //private EntidadesRepository _entidadesRepository;
        //private NotaDePedidoService _notaDePedidoService;
        //private NotaDePedidoRepository _notaDePedidoRepository;
        //private ClientesService _clientesService;
        //private ClientesRepository _clientesRepository;
        //private IMapper _mapper;

        //public NotaDePedidoControllerTests()
        //{
        //    this.SetUp();
        //}

        //public void SetUp()
        //{
        //    _entidadesRepository = new EntidadesRepository();
        //    _entidadesService = new EntidadesService(_entidadesRepository);
        //    _clientesRepository = new ClientesRepository();
        //    _clientesService = new ClientesService(_clientesRepository, _entidadesService); 
        //    _notaDePedidoRepository = new NotaDePedidoRepository();
        //    _notaDePedidoService = new NotaDePedidoService(_notaDePedidoRepository, _clientesService, _entidadesService, new ArticulosService(new ArticulosRepository()));
        //    _mapper = MapperGenerator.NotaDePedidoMapper();
        //}

        //[TestMethod]
        //public async Task Post_Exitoso_Retorna200()
        //{
        //    VentaInput ventaInput = new VentaInput()
        //    {
        //        IdComproba = "LNP",
        //        IdUsuario = "WEB",
        //        Cliente = "00902",
        //        Direccion = "BOULEVAR SAN MARTIN 2939",
        //        Localidad = "EL PALOMAR",
        //        Provincia = "BUENOS AIRES",
        //        CodPostal = "1712",
        //        Telefono = "4444-4444",
        //        Deposito = "001",
        //        Subtotal = 9300,
        //        Fecha = new DateTime(2020, 4, 20),
        //        PtoVenta = 1,
        //        Detalle = new List<DetalleInput>()
        //        {
        //            new DetalleInput()
        //            {
        //                IdArticulo = "BOFU0905",
        //                Cantidad = 1,
        //                Precio = 9000
        //            },
        //            new DetalleInput()
        //            {
        //                IdArticulo = "PLQA1600",
        //                Cantidad = 1,
        //                Precio = 300
        //            }
        //        },
        //        DatosFacturacion = new FacturacionInput()
        //        {
        //            Cuit = "20-17658292-9",
        //            Nombre = "DIGITAL CENTER",
        //            Direccion = "BOULEVAR SAN MARTIN 2939",
        //            Localidad = "EL PALOMAR",
        //            CodPostal = "1712",
        //            IdProvincia = "01 "
        //        }
        //    };
        //    //Act
        //    var data = await new NotaDePedidoController(_notaDePedidoService, _mapper).GrabarNotaDePedidoAsync(ventaInput);

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(OkObjectResult));

        //}

        //[TestMethod]
        //public async Task Post_Fallido_ArtiuloRetorna404()
        //{
        //    VentaInput ventaInput = new VentaInput()
        //    {
        //        IdComproba = "LNP",
        //        IdUsuario = "WEB",
        //        Cliente = "00902",
        //        Direccion = "BOULEVAR SAN MARTIN 2939",
        //        Localidad = "EL PALOMAR",
        //        Provincia = "BUENOS AIRES",
        //        CodPostal = "1712",
        //        Telefono = "4444-4444",
        //        Deposito = "001",
        //        Subtotal = 9300,
        //        Fecha = new DateTime(2020, 4, 20),
        //        PtoVenta = 1,
        //        Detalle = new List<DetalleInput>()
        //        {
        //            new DetalleInput()
        //            {
        //                IdArticulo = "MARIANO",
        //                Cantidad = 1,
        //                Precio = 9000
        //            },
        //            new DetalleInput()
        //            {
        //                IdArticulo = "PLQA1600",
        //                Cantidad = 1,
        //                Precio = 300
        //            }
        //        },
        //        DatosFacturacion = new FacturacionInput()
        //        {
        //            Cuit = "20-17658292-9",
        //            Nombre = "DIGITAL CENTER",
        //            Direccion = "BOULEVAR SAN MARTIN 2939",
        //            Localidad = "EL PALOMAR",
        //            CodPostal = "1712",
        //            IdProvincia = "01 "
        //        }
        //    };
        //    //Act
        //    var data = await new NotaDePedidoController(_notaDePedidoService, _mapper).GrabarNotaDePedidoAsync(ventaInput);

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(NotFoundObjectResult));
        //}

        //[TestMethod]
        //public async Task Post_Fallido_ClienteRetorna404()
        //{
        //    VentaInput ventaInput = new VentaInput()
        //    {
        //        IdComproba = "XXX",
        //        IdUsuario = "WEB",
        //        Cliente = "PEPIT",
        //        Direccion = "BOULEVAR SAN MARTIN 2939",
        //        Localidad = "EL PALOMAR",
        //        Provincia = "BUENOS AIRES",
        //        CodPostal = "1712",
        //        Telefono = "4444-4444",
        //        Deposito = "001",
        //        Subtotal = 9300,
        //        Fecha = new DateTime(2020, 4, 20),
        //        PtoVenta = 1,
        //        Detalle = new List<DetalleInput>()
        //        {
        //            new DetalleInput()
        //            {
        //                IdArticulo = "MARIANO",
        //                Cantidad = 1,
        //                Precio = 9000
        //            },
        //            new DetalleInput()
        //            {
        //                IdArticulo = "PLQA1600",
        //                Cantidad = 1,
        //                Precio = 300
        //            }
        //        },
        //        DatosFacturacion = new FacturacionInput()
        //        {
        //            Cuit = "20-17658292-9",
        //            Nombre = "DIGITAL CENTER",
        //            Direccion = "BOULEVAR SAN MARTIN 2939",
        //            Localidad = "EL PALOMAR",
        //            CodPostal = "1712",
        //            IdProvincia = "01 "
        //        }
        //    };
        //    //Act
        //    var data = await new NotaDePedidoController(_notaDePedidoService, _mapper).GrabarNotaDePedidoAsync(ventaInput);

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(NotFoundObjectResult));
        //}

        //[TestMethod]
        //public async Task Post_Fallido_ComprobanteRetorna404()
        //{
        //    VentaInput ventaInput = new VentaInput()
        //    {
        //        IdComproba = "ZZZ",
        //        IdUsuario = "WEB",
        //        Cliente = "00902",
        //        Direccion = "BOULEVAR SAN MARTIN 2939",
        //        Localidad = "EL PALOMAR",
        //        Provincia = "BUENOS AIRES",
        //        CodPostal = "1712",
        //        Telefono = "4444-4444",
        //        Deposito = "001",
        //        Subtotal = 9300,
        //        Fecha = new DateTime(2020, 4, 20),
        //        PtoVenta = 1,
        //        Detalle = new List<DetalleInput>()
        //        {
        //            new DetalleInput()
        //            {
        //                IdArticulo = "MARIANO",
        //                Cantidad = 1,
        //                Precio = 9000
        //            },
        //            new DetalleInput()
        //            {
        //                IdArticulo = "PLQA1600",
        //                Cantidad = 1,
        //                Precio = 300
        //            }
        //        },
        //        DatosFacturacion = new FacturacionInput()
        //        {
        //            Cuit = "20-17658292-9",
        //            Nombre = "DIGITAL CENTER",
        //            Direccion = "BOULEVAR SAN MARTIN 2939",
        //            Localidad = "EL PALOMAR",
        //            CodPostal = "1712",
        //            IdProvincia = "01 "
        //        }
        //    };
        //    //Act
        //    var data = await new NotaDePedidoController(_notaDePedidoService, _mapper).GrabarNotaDePedidoAsync(ventaInput);

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(NotFoundObjectResult));
        //}

        //[TestMethod]
        //public async Task Post_Fallido_SinArticulosRetorna400()
        //{
        //    VentaInput ventaInput = new VentaInput()
        //    {
        //        IdComproba = "XXX",
        //        IdUsuario = "WEB",
        //        Cliente = "00902",
        //        Direccion = "BOULEVAR SAN MARTIN 2939",
        //        Localidad = "EL PALOMAR",
        //        Provincia = "BUENOS AIRES",
        //        CodPostal = "1712",
        //        Telefono = "4444-4444",
        //        Deposito = "001",
        //        Subtotal = 9300,
        //        Fecha = new DateTime(2020, 4, 20),
        //        PtoVenta = 1,
        //        DatosFacturacion = new FacturacionInput()
        //        {
        //            Cuit = "20-17658292-9",
        //            Nombre = "DIGITAL CENTER",
        //            Direccion = "BOULEVAR SAN MARTIN 2939",
        //            Localidad = "EL PALOMAR",
        //            CodPostal = "1712",
        //            IdProvincia = "01 "
        //        }
        //    };
        //    //Act
        //    var data = await new NotaDePedidoController(_notaDePedidoService, _mapper).GrabarNotaDePedidoAsync(ventaInput);

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(BadRequestObjectResult));
        //}

        //[TestMethod]
        //public async Task Post_Fallido_SinDepositoRetorna400()
        //{
        //    VentaInput ventaInput = new VentaInput()
        //    {
        //        IdComproba = "XXX",
        //        IdUsuario = "WEB",
        //        Cliente = "00902",
        //        Direccion = "BOULEVAR SAN MARTIN 2939",
        //        Localidad = "EL PALOMAR",
        //        Provincia = "BUENOS AIRES",
        //        CodPostal = "1712",
        //        Telefono = "4444-4444",
        //        Subtotal = 9300,
        //        Fecha = new DateTime(2020, 4, 20),
        //        PtoVenta = 1,
        //        Detalle = new List<DetalleInput>()
        //        {
        //            new DetalleInput()
        //            {
        //                IdArticulo = "BOFU0905",
        //                Cantidad = 1,
        //                Precio = 9000
        //            },
        //            new DetalleInput()
        //            {
        //                IdArticulo = "PLQA1600",
        //                Cantidad = 1,
        //                Precio = 300
        //            }
        //        },
        //        DatosFacturacion = new FacturacionInput()
        //        {
        //            Cuit = "20-17658292-9",
        //            Nombre = "DIGITAL CENTER",
        //            Direccion = "BOULEVAR SAN MARTIN 2939",
        //            Localidad = "EL PALOMAR",
        //            CodPostal = "1712",
        //            IdProvincia = "01 "
        //        }
        //    };
        //    //Act
        //    var data = await new NotaDePedidoController(_notaDePedidoService, _mapper).GrabarNotaDePedidoAsync(ventaInput);

        //    //Assert
        //    Assert.IsInstanceOfType(data.Result, typeof(BadRequestObjectResult));
        //}
    }
}
