using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Domain.Usuario
{
    public class Cliente : Usuario
    {
        private string Nombre { get; set; }
        private string Apellido { get; set; }
        private string Cedula { get; set; }
        private List<Domain.Producto.Producto> ProductosRegistrados { get; set; }
        public Cliente () { }
        public Cliente(int id, string nombre, string apellido, string cedula, string telefono, string correo, string celular, string direccion, string contrasena) 
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Cedula = cedula;
            this.Telefono = telefono;
            this.Correo = correo;
            this.Direccion = direccion;
            this.Contrasena = contrasena;
            this.ProductosRegistrados = new List<Producto.Producto>();
        }

    }
}
