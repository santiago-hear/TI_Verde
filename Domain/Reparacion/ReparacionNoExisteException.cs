using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Reparacion
{
    [Serializable]
    public class ReparacionNoExisteException : Exception
    {
        public ReparacionNoExisteException(){}
        public ReparacionNoExisteException(string msg) : base(msg){}
        public ReparacionNoExisteException(string msg, Exception inner) : base(msg,inner) { }
    }
}
