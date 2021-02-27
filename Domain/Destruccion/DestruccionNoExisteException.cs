using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Destruccion
{
    
    public class DestruccionNoExisteException : Exception
    {
        public DestruccionNoExisteException(){}
        public DestruccionNoExisteException(string msg) : base(msg){}
        public DestruccionNoExisteException(string msg, Exception inner) : base(msg,inner) { }
    }
}
