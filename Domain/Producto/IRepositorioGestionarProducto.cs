using Domain.Producto;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Producto
{
    public interface IRepositorioGestionarProducto
    {
        void RegistrarProducto(Producto producto);
        int GetMaxId();
        Producto GetProducto(int id);
        List<Producto> GetAllProductos();
        List<Producto> ObtenerInforme(DateTime fecha);

    }
}
