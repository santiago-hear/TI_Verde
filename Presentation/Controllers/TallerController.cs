using System;
using ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.GestionAsignacion;
using ApplicationCore.RegistrarReparacion;

namespace Presentation.Controllers
{
    public class TallerController : Controller
    {
        readonly ControlGestionarAsignaciones controlAsignaciones;
        readonly ControlReparaciones controlReparaciones;

        public TallerController()
        {
            controlAsignaciones = new ControlGestionarAsignaciones();
            controlReparaciones = new ControlReparaciones();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerAsignaciones()
        {
            int tallerId = 1;
            try
            {
                ViewBag.productosAs = controlAsignaciones.GetProductosAsignados(tallerId);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
        public IActionResult RegistrarReparacion()
        {
            int tallerId = 1;
            try
            {
                ViewBag.ProductosTaller = controlReparaciones.GetProductosParaReparar(tallerId);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
        [HttpPost]
        public IActionResult RegistrarReparacion(int productId, string descripcion, float costo, string rutaImagen)
        {
            int tallerId = 1;
            try
            {
                controlReparaciones.RegistrarReparacion(descripcion, productId, tallerId, costo, rutaImagen);
                ViewBag.Reparaciones = controlReparaciones.GetReparaciones(tallerId);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View("VerReparaciones");
        }
        public IActionResult VerReparaciones()
        {
            int tallerId = 1;
            try
            {
                ViewBag.Reparaciones = controlReparaciones.GetReparaciones(tallerId);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
    }
}
