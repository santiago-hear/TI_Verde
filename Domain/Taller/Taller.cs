using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;

namespace Domain.Area
{
    public class Taller
    {
        public Taller() { }
        public Taller(int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Asignaciones = new List<Producto.Producto>();
            Arreglos = new List<Producto.Producto>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Producto.Producto> Asignaciones { get; set; }
        public List<Producto.Producto> Arreglos { get; set; }
    }
}
