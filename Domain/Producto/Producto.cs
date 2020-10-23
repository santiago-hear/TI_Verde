using System;
using System.Collections.Generic;
using System.Text;
using Domain.TipoProducto;

namespace Domain.Producto
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Marca { get; set; }
        public int TiempoDeUso { get; set; }
        public TipoProducto.TipoProducto TipoProducto { get; set; }
        public string Referencia { get; set; }
        public float PrecioCompra { get; set; }
        public float PrecioVenta { get; set; }
        public string Estado { get; set; }
        public string Nombre { get { return Marca + " " + Referencia; } }
        public Producto() { }
        public Producto(int id, string descripcion, DateTime fechaIngreso, string marca, int tiempoDeUso, TipoProducto.TipoProducto tipoProducto, string referencia)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.FechaIngreso = fechaIngreso;
            this.Marca = marca;
            this.TiempoDeUso = tiempoDeUso;
            this.TipoProducto = tipoProducto;
            this.Referencia = referencia;
            this.PrecioCompra = 0;
            this.PrecioVenta = 0;
            this.Estado = "Inscrito";
        }
        
    }
}
