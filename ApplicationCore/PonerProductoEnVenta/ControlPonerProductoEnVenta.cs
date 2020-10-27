using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;
using Persistence.Repositories;

namespace ApplicationCore.PonerProductoEnVenta
{
    public class ControlPonerProductoEnVenta
    {
        readonly IRepositorioProductos repositorioProductos;

        public ControlPonerProductoEnVenta()
        {
            repositorioProductos = new RepositorioProductos();
        }

        public List<Producto> DisponoblesParaVenta()
        {
            List<Producto> productos = repositorioProductos.GetProductos();
            return productos.FindAll(p => p.Estado.Equals("Reparado"));
        }

        public void PonerProductoEnVenta(int id, float precio) 
        {    
            try
            {
                string estado = "En Venta";
                Producto producto = repositorioProductos.BuscarProducto(id);
                Producto productoActualizado = producto;
                productoActualizado.PrecioVenta = precio;
                productoActualizado.Estado = estado;
                repositorioProductos.ActualizarProducto(producto, productoActualizado);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> GetProductosEnVenta()
        {
            List<Producto> productos = repositorioProductos.GetProductos();
            return productos.FindAll(p => p.Estado.Equals("En Venta"));
        }
    }
}
