using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;
using Persistence.Repositories;

namespace ApplicationCore.PonerProductoEnVenta
{
    public class ControlPonerProductoEnVenta
    {
        readonly IRepositorioAsignarProducto repoProdV = new RepositorioAsignarProducto();
        readonly IRepositorioGestionarProducto repoProd = new RepositorioGestionarProducto();
        public void PonerProuctoEnVenta(int id, float precio) {
            
            try
            {
                bool esta = repoProdV.GetProductoEnVenta(id);

                if (!esta)
                {
                    Producto producto = repoProd.GetProducto(id);
                    producto.PrecioVenta = precio;
                    repoProdV.PonerEnVenta(producto);
                }
            }
            catch(ProductoEnVentaException ex)
            {
                throw ex;
            }
        }

        public List<Producto> getProductosEnVenta()
        {
            return repoProdV.GetProductosEnVenta();
        }
    }
}
