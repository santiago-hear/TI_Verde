using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Usuario
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Contrasena { get; set; }
    }
}
