using ApplicationCore.ObtenerInformeMensual;
using Domain.Producto;
using NUnit.Framework;
using System;

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
                //List<Producto> p = ControlInforme.ObtenerInformeProductosMensual(DateTime.Now);
                //Assert.That(p, Is.Not.Null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
