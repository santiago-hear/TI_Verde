using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Producto
{
    [Serializable]
    public class NoHayProductosMesException : Exception
    {
        public NoHayProductosMesException() { }
        public NoHayProductosMesException(string msg) : base(msg) { }
        public NoHayProductosMesException(string msg, Exception inner) : base(msg, inner) { }
    }
}
