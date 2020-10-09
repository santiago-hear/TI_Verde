using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Producto
{
    [Serializable]
    public class ProductoNoExisteException : Exception
    {
        public ProductoNoExisteException(){}
        public ProductoNoExisteException(string msg) : base(msg){}
        public ProductoNoExisteException(string msg, Exception inner) : base(msg,inner) { }
    }
}
