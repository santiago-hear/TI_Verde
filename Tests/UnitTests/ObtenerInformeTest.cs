using ApplicationCore;
using Domain.Producto;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.UnitTests
{
    class ObtenerInformeTest
    {
        private readonly ControlObtenerInformeMensual ControlInforme = new ControlObtenerInformeMensual();
        [Test]
        public void NoExistenProductosParaElMes()
        {
            try
            {
                List<Producto> p = ControlInforme.ObtenerInformeProductosMensual(DateTime.Now);
                Assert.That(p, Is.Not.Null);
            }
            catch (NoHayProductosMesException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
