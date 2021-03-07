using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Reparacion
{
    public class Reparacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public float Costo { get; set; }
        public DateTime FechaReparacion { get; set; }
        public Producto.Producto ProductoReparado { get; set; }
        public string Imagen { get; set; }
        public Reparacion() { }
        public Reparacion(int id, string descripcion, float costo, DateTime fechaReparacion, Producto.Producto productoReparado, string imagen) 
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.FechaReparacion = fechaReparacion;
            this.ProductoReparado = productoReparado;
            this.Imagen = imagen;
        }
    }
}
