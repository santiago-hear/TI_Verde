﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.TipoProducto
{
    public interface IRepositorioTiposProductos
    {
        List<TipoProducto> GetTiposProductos();
        void RegistrarTipoProducto(TipoProducto tipoProducto);
        TipoProducto BuscarTipoProducto(int Id);
        void EliminarTipoProducto(int Id);
        int GetMaxIdTiposProductos();
    }
}
