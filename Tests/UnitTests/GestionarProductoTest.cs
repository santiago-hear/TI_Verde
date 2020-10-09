using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore;
using Domain.Producto;

namespace Tests.UnitTests
{
    class GestionarProductoTest
    {
        #pragma warning disable IDE0052 // Remove unread private members
        private readonly ControlGestionarProducto ControlProducto = new ControlGestionarProducto();
        #pragma warning restore IDE0052 // Remove unread private members
        [Test]
        public void ProductoExiste()
        {
            Producto p = ControlProducto.GetProducto(1);
            Assert.That(1,Is.EqualTo(p.Id));
        }
        [Test]
        public void ObtenerProductos()
        {
            List<Producto> Productos = ControlProducto.GetAllProductos();
            Assert.That(Productos, Is.Not.Null);
        }

    }
}
