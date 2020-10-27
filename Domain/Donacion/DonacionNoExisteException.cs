using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Donacion
{
    [Serializable]
    public class DonacionNoExisteException : Exception
    {
        public DonacionNoExisteException(){}
        public DonacionNoExisteException(string msg) : base(msg){}
        public DonacionNoExisteException(string msg, Exception inner) : base(msg,inner) { }
    }
}
