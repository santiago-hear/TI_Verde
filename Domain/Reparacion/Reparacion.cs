using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Reparacion
{
    public class Reparacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaReparacion { get; set; }
        public Producto.Producto ProductoReparado { get; set; }
        public Reparacion() { }
        public Reparacion(int id, string descripcion, DateTime fechaReparacion, Producto.Producto productoReparado) 
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.FechaReparacion = fechaReparacion;
            this.ProductoReparado = productoReparado;
        }
    }
}
