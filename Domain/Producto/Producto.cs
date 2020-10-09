using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Producto
{
    public class Producto
    {
        public Producto() { }
        public Producto(int id, string descripcion, DateTime fechaIngreso, string marca, int tiempoDeUso, string categoria, string referencia)
        {
            Id = id;
            Descripcion = descripcion;
            FechaIngreso = fechaIngreso;
            Marca = marca;
            TiempoDeUso = tiempoDeUso;
            Categoria = categoria;
            Referencia = referencia;
            Precio = 0;

        }

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Marca { get; set; }
        public int TiempoDeUso { get; set; }
        public string Categoria { get; set; }
        public string Referencia { get; set; }
        public float Precio { get; set; }
        public string Nombre { get { return Marca +" "+ Referencia; }}
    }
}
