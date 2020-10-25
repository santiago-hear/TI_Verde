﻿using Domain.Producto;
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
        void ActualizarEstado(Producto producto, string estado);

        //void RegistrarProducto(Producto producto);
        //int GetMaxId();
        //Producto GetProducto(int id);
        //List<Producto> GetAllProductos();
        //List<Producto> ObtenerInforme(DateTime fecha);

    }
}