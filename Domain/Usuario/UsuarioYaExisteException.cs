using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Usuario
{
    [Serializable]
    public class UsuarioYaExisteException : Exception
    {
        public UsuarioYaExisteException() { }
        public UsuarioYaExisteException(string msg) : base(msg) { }
        public UsuarioYaExisteException(string msg, Exception inner) : base(msg, inner) { }
    }
}
