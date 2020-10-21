using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;

namespace Domain.Taller
{
    public class Taller
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<Producto.Producto> Asignaciones { get; set; }
        public List<Producto.Producto> Arreglos { get; set; }
        public Taller() { }
        public Taller(int id, string nombre, string direccion, string telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Asignaciones = new List<Producto.Producto>();
            this.Arreglos = new List<Producto.Producto>();
        }
    }
}
