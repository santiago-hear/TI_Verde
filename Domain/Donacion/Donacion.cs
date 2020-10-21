using System;
using System.Collections.Generic;
using System.Text;
using Domain.Usuario;
using Domain.Producto;

namespace Domain.Donacion
{
    public class Donacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Producto.Producto ProductoDonado { get; set; }
        public Institucion InstitucionBeneficiada { get; set; }
        public Donacion() { }
        public Donacion(int id, string descripcion, Producto.Producto productoDonado, Institucion institucionBeneficiada) 
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.ProductoDonado = productoDonado;
            this.InstitucionBeneficiada = institucionBeneficiada;
        }
    }
}
