using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Pago
{
    public class Pago
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public string Descripcion { get; set; }
        public List<Producto.Producto> ProductosPagados { get; set; }
        public Pago() { }
        public Pago(int id, float valor, string descripcion) 
        {
            this.Id = id;
            this.Valor = valor;
            this.Descripcion = descripcion;
            this.ProductosPagados = new List<Producto.Producto>();
        }
    }
}
