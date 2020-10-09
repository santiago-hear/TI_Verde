using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Producto
{
    [Serializable]
    public class ProductoEnVentaException: Exception
    {
        public ProductoEnVentaException() { }
        public ProductoEnVentaException(string msg) : base(msg) { }
        public ProductoEnVentaException(string msg, Exception inner) : base(msg, inner) { }
    }
}
