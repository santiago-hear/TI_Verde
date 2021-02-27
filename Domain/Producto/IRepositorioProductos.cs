using Domain.Producto;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Producto
{
    public interface IRepositorioProductos
    {
        List<Producto> GetProductos();
        void RegistrarProducto(Producto producto);
        Producto BuscarProducto(int id);
        void EliminarProducto(int id);
        int GetMaxIdProductos();
        void ActualizarProducto(Producto productoAntiguo, Producto productoNuevo);

    }
}
