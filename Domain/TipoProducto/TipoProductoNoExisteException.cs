using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TipoProducto
{
    [Serializable]
    public class TipoProductoNoExisteException : Exception
    {
        public TipoProductoNoExisteException(){}
        public TipoProductoNoExisteException(string msg) : base(msg){}
        public TipoProductoNoExisteException(string msg, Exception inner) : base(msg,inner) { }
    }
}
