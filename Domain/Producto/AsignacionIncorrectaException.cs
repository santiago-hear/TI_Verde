using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Producto
{
    public class AsignacionIncorrectaException : Exception
    {
        public AsignacionIncorrectaException() { }
        public AsignacionIncorrectaException(string msg) : base(msg) { }
        public AsignacionIncorrectaException(string msg, Exception inner) : base(msg, inner) { }
    }
}

