using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Institucion
{
    public class Institucion
    {
        public Institucion() { }
        public Institucion (int id, string nombre, string direccion)
        {
            Id = id;
            Nombre = nombre;
            Direccion = direccion;
            Asignaciones = new List<Producto.Producto>();
            Solicitudes = new List<Producto.Producto>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Producto.Producto> Asignaciones { get; set; }
        public List<Producto.Producto> Solicitudes { get; set; }
    }
}
