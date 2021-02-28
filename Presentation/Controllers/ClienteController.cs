using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly ControlGestionarProducto controlGestionProducto;
        public ClienteController(ILogger<HomeController> logger)
        {
            _logger = logger;
            controlGestionProducto = new ControlGestionarProducto();
        }
        public IActionResult Index()
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
    }
}
