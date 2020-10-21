using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Destruccion
{
    public class Destruccion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaDestruccion { get; set; }
        public string ImagenPrueba { get; set; }
        public Producto.Producto ProductoDestruido { get; set; }
        public Destruccion() { }
        public Destruccion(int id, string descripcion, DateTime fechaDestruccion, string ImagenPrueba, Producto.Producto ProductoDestruido) 
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.FechaDestruccion = fechaDestruccion;
            this.ImagenPrueba = ImagenPrueba;
            this.ProductoDestruido = ProductoDestruido;
        }
    }
}
