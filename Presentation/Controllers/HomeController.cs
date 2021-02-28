using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Models;
using ApplicationCore;
using Domain.Producto;
using ApplicationCore.PonerProductoEnVenta;
using ApplicationCore.RegistrarUsuario;
using Domain.Usuario;
using Domain.TipoProducto;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ControlGestionarProducto controlGestionProducto;
        readonly ControlObtenerInformeMensual controlInforme;
        readonly ControlPonerProductoEnVenta ControlVenta;
        readonly ControlRegistrarUsuario ControlUsuarios;
        readonly ControlAsignarProducto controlAsignar;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            controlGestionProducto = new ControlGestionarProducto();
            controlInforme = new ControlObtenerInformeMensual();
            ControlVenta = new ControlPonerProductoEnVenta();
            ControlUsuarios = new ControlRegistrarUsuario();
            controlAsignar = new ControlAsignarProducto();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RegistrarProducto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarProducto(string descripcion, string marca, int tiempoDeUso, int Idcategoria, string referencia)
        {
            controlGestionProducto.RegistrarProducto(descripcion, marca, tiempoDeUso, Idcategoria, referencia);
            return View();
        }

        [HttpGet]
        public IActionResult BuscarProducto(int id)
        {
            if (id == 0)
            {
                ViewBag.ventana = "todos";
                ViewBag.Productos = controlGestionProducto.GetProductos();
            }
            else if (id > 0)
            {
                try
                {
                    ViewBag.ventana = "uno";
                    //ViewBag.Producto = controlGestionProducto.GetProducto(id);
                }
                catch(InstitucionNoExisteException ex){
                    ViewBag.ventana = "Error: " + ex.Message;
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ObtenerInforme(DateTime mes)
        {
            if (mes.Month != 0)
            {
                try
                {
                    //ViewBag.productos = controlInforme.ObtenerInformeProductosMensual(mes);
                }
                catch (Exception ex)
                {
                    ViewBag.message = "Error: " + ex.Message;
                }
            }
            else
            {
                ViewBag.productos = new List<Producto>();
            }
            
            return View();
        }

        public IActionResult ProductosEnVenta()
        {
            ViewBag.productos = controlGestionProducto.GetProductos();
            //ViewBag.productosEnVenta = ControlVenta.getProductosEnVenta();
            return View();
        }

        [HttpPost]
        public IActionResult ProductosEnVenta(int id, float precio)
        {
            ViewBag.productos = controlGestionProducto.GetProductos();
            try
            {
                ControlVenta.PonerProductoEnVenta(id, precio);
            }
            catch(Exception ex)
            {
                ViewBag.message = "Error: " + ex.Message;
            }
            //ViewBag.productosEnVenta = ControlVenta.getProductosEnVenta();
            return View();
        }
        
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(string cedula, string nombre, string apellido, string celular,string correo, string contraseña)
        {
            try
            {
                //ControlUsuarios.RegistrarUsuario(cedula, nombre, apellido, celular, correo, contraseña);
            }
            catch (Exception ex)
            {
                ViewBag.message = "ERROR: " + ex.Message;
            }
            return View();
        }

        public IActionResult AsignarProducto()
        {
            ViewBag.instituciones = controlAsignar.GetInstituciones();
            ViewBag.talleres = controlAsignar.GetTalleres();
            ViewBag.productos = controlGestionProducto.GetProductos();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
