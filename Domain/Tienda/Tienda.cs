using System;
using System.Collections.Generic;
using System.Text;
using Domain.Inspeccion;

namespace Domain.Tienda
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public List<Inspeccion.Inspeccion> Inspecciones { get; set; }
        public Tienda() { }
        public Tienda(int id, string nombre, string telefono, string direccion) 
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Inspecciones = new List<Inspeccion.Inspeccion>();
        }
    }
}
