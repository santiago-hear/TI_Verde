using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Usuario
{
    public class Usuario
    {
        public Usuario(int id, string cedula, string nombre, string apellido, string correo, string celular, string contraseña)
        {
            this.Id = id;
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;
            this.Celular = celular;
            this.Contraseña = contraseña;
        }

        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public string Contraseña { get; set; }
    }
}
