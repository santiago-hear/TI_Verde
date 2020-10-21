using System;
using System.Collections.Generic;
using System.Text;
using Domain.Usuario;

namespace Domain.Kiosco
{
    public class Kiosco
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Producto.Producto> ProductosRecibidos { get; set; }
        public Kiosco() { }
        public Kiosco(int Id, string nombre, string direccion) 
        {
            this.Id = Id;
            this.Nombre = nombre;
            this.Direccion = direccion;
        }
    }
}
