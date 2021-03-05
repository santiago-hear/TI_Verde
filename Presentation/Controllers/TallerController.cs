using System;
using ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.GestionAsignacion;

namespace Presentation.Controllers
{
    public class TallerController : Controller
    {
        readonly ControlGestionarAsignaciones controlAsignaciones;

        public TallerController ()
        {
            controlAsignaciones = new ControlGestionarAsignaciones();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerAsignaciones()
        {
            try
            {
                ViewBag.productosAs = controlAsignaciones.GetProductosAsignados(1);
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
    }
}
