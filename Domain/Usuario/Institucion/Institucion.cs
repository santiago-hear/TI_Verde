using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Usuario
{
    public class Institucion : Usuario
    {
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public List<Producto.Producto> Asignaciones { get; set; }
        public List<Producto.Producto> Solicitudes { get; set; }
        public Institucion() { }
        public Institucion(int id, string nombre, string nit, string telefono, string correo, string celular, string direccion, string contrasena)
        { 
            this.Id = id;
            this.Nombre = nombre;
            this.Nit = nit;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Celular = celular;
            this.Direccion = direccion;
            this.Contrasena = contrasena;
            this.Asignaciones = new List<Producto.Producto>();
            this.Solicitudes = new List<Producto.Producto>();
        }
    }
}
