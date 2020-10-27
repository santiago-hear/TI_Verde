using System;
using System.Collections.Generic;
using ApplicationCore;
using ApplicationCore.ConfigurarTipoProducto;
using ApplicationCore.PonerProductoEnVenta;
using Domain.Producto;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class TiendaController : Controller
    {
        readonly ControlGestionarProducto controlGestionProducto;
        readonly ControlAsignarProducto controlAsignarProducto;
        readonly ControlPonerProductoEnVenta ControlProductoVenta;
        readonly ControlConfigurarTipoProducto controlTiposProductos;


        public TiendaController()
        {
            controlGestionProducto = new ControlGestionarProducto();
            controlAsignarProducto = new ControlAsignarProducto();
            ControlProductoVenta = new ControlPonerProductoEnVenta();
            controlTiposProductos = new ControlConfigurarTipoProducto();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GestionarProductos()
        {
            try
            {
                ViewBag.Productos = controlGestionProducto.GetProductos();
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        public IActionResult AsignarProducto()
        {
            try
            {
                ViewBag.productosTaller = controlAsignarProducto.DisponiblesParaTaller();
                ViewBag.productosInstitucion = controlAsignarProducto.DisponiblesParaInstitucion();
                ViewBag.instituciones = controlAsignarProducto.GetInstituciones();
                ViewBag.talleres = controlAsignarProducto.GetTalleres();
                ViewBag.productosDestruccion = controlAsignarProducto.DisponiblesParaDestruccion();
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
        [HttpPost]
        public IActionResult AsignarATaller(int idtaller, int idProducto)
        {
            try
            {
                ViewBag.productosTaller = controlAsignarProducto.DisponiblesParaTaller();
                ViewBag.productosInstitucion = controlAsignarProducto.DisponiblesParaInstitucion();
                ViewBag.instituciones = controlAsignarProducto.GetInstituciones();
                ViewBag.talleres = controlAsignarProducto.GetTalleres();
                ViewBag.productosDestruccion = controlAsignarProducto.DisponiblesParaDestruccion();
                controlAsignarProducto.AsignarProductoTaller(idtaller, idProducto);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View("AsignarProducto");
        }

        [HttpPost]
        public IActionResult AsignarAInstitucion(int idInstitucion, int idProducto, string descripcionDonacion)
        {
            try
            {
                ViewBag.productosTaller = controlAsignarProducto.DisponiblesParaTaller();
                ViewBag.productosInstitucion = controlAsignarProducto.DisponiblesParaInstitucion();
                ViewBag.instituciones = controlAsignarProducto.GetInstituciones();
                ViewBag.talleres = controlAsignarProducto.GetTalleres();
                ViewBag.productosDestruccion = controlAsignarProducto.DisponiblesParaDestruccion();
                controlAsignarProducto.AsignarProductoInstitucion(idInstitucion, idProducto, descripcionDonacion);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View("AsignarProducto");
        }

        [HttpPost]
        public IActionResult AsignarADestruccion(string descripcionDestruccion, string imagenPrueba, int idProducto)
        {
            try
            {
                ViewBag.productosTaller = controlAsignarProducto.DisponiblesParaTaller();
                ViewBag.productosInstitucion = controlAsignarProducto.DisponiblesParaInstitucion();
                ViewBag.instituciones = controlAsignarProducto.GetInstituciones();
                ViewBag.talleres = controlAsignarProducto.GetTalleres();
                ViewBag.productosDestruccion = controlAsignarProducto.DisponiblesParaDestruccion();
                controlAsignarProducto.AsignarProductoDestruccion(descripcionDestruccion, imagenPrueba, idProducto);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View("AsignarProducto");
        }
        public IActionResult ConfigurarTipo()
        {
            try
            {
                ViewBag.inventario = controlTiposProductos.GetTiposProductos();
                ViewBag.configurados = controlTiposProductos.GetTiposProductosConfigurados();
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult ConfigurarTipo(string Tipos)
        {
            ViewBag.inventario = controlTiposProductos.GetTiposProductos();
            ViewBag.configurados = controlTiposProductos.GetTiposProductosConfigurados();
            ViewBag.info = Tipos;
            //try
            //{
            //    controlTiposProductos.ConfigurarTiposProductos(Tipos);
            //    ViewBag.inventario = controlTiposProductos.GetTiposProductos();
            //    ViewBag.configurados = controlTiposProductos.GetTiposProductosConfigurados();
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.ErrorMessage = ex.Message;
            //}
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
        /////////////////////////////////////////////// PRODUCTOS EN VENTA /////////////////////////////////////////////////////
        public IActionResult ProductosEnVenta()
        {
            try
            {
                ViewBag.productosEnVenta = ControlProductoVenta.GetProductosEnVenta();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        public IActionResult PonerEnVenta()
        {
            try
            {
                ViewBag.productosParaVender = ControlProductoVenta.DisponoblesParaVenta();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult PonerEnVenta(int IdProducto, float precio)
        {
            try
            {
                ControlProductoVenta.PonerProductoEnVenta(IdProducto, precio);
                ViewBag.productosParaVender = ControlProductoVenta.DisponoblesParaVenta();
            }
            catch (Exception ex)
            {
                ViewBag.message = "Error: " + ex.Message;
            }
            return View("ProductosEnVenta");
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

        public IActionResult RegistarInspeccion()
        {
            return View();
        }

        public IActionResult RealizarSeguimiento()
        {
            return View();
        }
    }
}
