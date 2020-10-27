using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Taller
{
    [Serializable]
    public class TallerNoExisteException : Exception
    {
        public TallerNoExisteException(){}
        public TallerNoExisteException(string msg) : base(msg){}
        public TallerNoExisteException(string msg, Exception inner) : base(msg,inner) { }
    }
}
