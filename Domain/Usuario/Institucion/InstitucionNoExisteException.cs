using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Usuario
{
    [Serializable]
    public class InstitucionNoExisteException : Exception
    {
        public InstitucionNoExisteException(){}
        public InstitucionNoExisteException(string msg) : base(msg){}
        public InstitucionNoExisteException(string msg, Exception inner) : base(msg,inner) { }
    }
}
