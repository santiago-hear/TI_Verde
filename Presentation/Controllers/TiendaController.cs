using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore;
using ApplicationCore.PonerProductoEnVenta;
using ApplicationCore.RegistrarUsuario;
using Domain.Producto;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TiendaController : Controller
    {
        readonly ControlGestionarProducto controlGestionProducto;
        //readonly ControlObtenerInformeMensual controlInforme;
        //readonly ControlPonerProductoEnVenta ControlVenta;
        //readonly ControlRegistrarUsuario ControlUsuarios;
        readonly ControlAsignarProducto controlAsignar;

        public TiendaController()
        {
            controlGestionProducto = new ControlGestionarProducto();
            //controlInforme = new ControlObtenerInformeMensual();
            //ControlVenta = new ControlPonerProductoEnVenta();
            //ControlUsuarios = new ControlRegistrarUsuario();
            controlAsignar = new ControlAsignarProducto();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GestionarProductos()
        {
            ViewBag.Productos = controlGestionProducto.GetAllProductos();
            return View();
        }

        public IActionResult AsignarProducto()
        {
            ViewBag.productosTaller = controlAsignar.DisponiblesParaTaller();
            ViewBag.productosInstitucion = controlAsignar.DisponiblesParaInstitucion();
            ViewBag.instituciones = controlAsignar.GetInstituciones();
            ViewBag.talleres = controlAsignar.GetTalleres();
            ViewBag.productos = controlGestionProducto.GetAllProductos();
            return View();
        }
        [HttpPost]
        public IActionResult AsignarATaller(int idtaller, int idProducto)
        {
            ViewBag.productosTaller = controlAsignar.DisponiblesParaTaller();
            ViewBag.productosInstitucion = controlAsignar.DisponiblesParaInstitucion();
            ViewBag.instituciones = controlAsignar.GetInstituciones();
            ViewBag.talleres = controlAsignar.GetTalleres();
            ViewBag.productos = controlGestionProducto.GetAllProductos();
            controlAsignar.AsignarProductoTaller(idtaller, idProducto);
            return View("AsignarProducto");
        }
        [HttpPost]
        public IActionResult AsignarAInstitucion(int idInstitucion, int idProducto)
        {
            ViewBag.productosTaller = controlAsignar.DisponiblesParaTaller();
            ViewBag.productosInstitucion = controlAsignar.DisponiblesParaInstitucion();
            ViewBag.instituciones = controlAsignar.GetInstituciones();
            ViewBag.talleres = controlAsignar.GetTalleres();
            ViewBag.productos = controlGestionProducto.GetAllProductos();
            controlAsignar.AsignarProductoInstitucion(idInstitucion, idProducto);
            return View("AsignarProducto");
        }
        public IActionResult ConfigurarTipo()
        {
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
                catch (NoHayProductosMesException ex)
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
            ViewBag.productos = controlGestionProducto.GetAllProductos();
            //ViewBag.productosEnVenta = ControlVenta.getProductosEnVenta();
            return View();
        }

        [HttpPost]
        public IActionResult PonerEnVenta(int id, float precio)
        {
            ViewBag.productos = controlGestionProducto.GetAllProductos();
            try
            {
                //ControlVenta.PonerProuctoEnVenta(id, precio);
            }
            catch (ProductoEnVentaException ex)
            {
                ViewBag.message = "Error: " + ex.Message;
            }
            //ViewBag.productosEnVenta = ControlVenta.getProductosEnVenta();
            return View();
        }

        public IActionResult VerPagos()
        {
            return View();
        }

        public IActionResult RealizarPago()
        {
            return View();
        }

        public IActionResult GestionarInspecciones()
        {
            return View();
        }

        public IActionResult RealizarInspeccion()
        {
            return View();
        }

        public IActionResult RealizarSeguimiento()
        {
            return View();
        }
    }
}
