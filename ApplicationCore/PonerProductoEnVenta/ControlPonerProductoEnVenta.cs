using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;
using Persistence.Repositories;

namespace ApplicationCore.PonerProductoEnVenta
{
    public class ControlPonerProductoEnVenta
    {
        readonly IRepositorioInstituciones repoProdV = new RepositorioInstituciones();
        readonly IRepositorioProductos repoProd = new RepositorioProductos();
        public void PonerProuctoEnVenta(int id, float precio) {
            
            try
            {
                //bool esta = repoProdV.GetProductoEnVenta(id);

                //if (!esta)
                //{
                //    Producto producto = repoProd.GetProducto(id);
                //    producto.PrecioVenta = precio;
                //    repoProdV.PonerEnVenta(producto);
                //}
            }
            catch(ProductoEnVentaException ex)
            {
                throw ex;
            }
        }

        //public List<Producto> getProductosEnVenta()
        //{
        //    return repoProdV.GetProductosEnVenta();
        //}
    }
}
