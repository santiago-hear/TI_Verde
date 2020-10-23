using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TipoProducto
{
    public class TipoProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public TipoProducto() { }
        public TipoProducto(int id, string nombre, string descripcion) 
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
    }
}
