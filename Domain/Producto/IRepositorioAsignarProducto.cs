using Domain.Area;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Producto
{
    public interface IRepositorioAsignarProducto
    {
        bool GetProductoEnVenta(int id);
        void PonerEnVenta(Producto producto);
        List<Producto> GetProductosEnVenta();
        void AsignarAInstitucion(Producto p, Institucion.Institucion i);
        Institucion.Institucion BuscarInstitucion(int Id);
        Taller BuscarTaller(int Id);
        void RegistrarDestruccion(Producto p);
        void AsignarATaller(Producto p, Taller t);
        List<Taller> getTalleres();
        List<Institucion.Institucion> getInstituciones();
    }
}
