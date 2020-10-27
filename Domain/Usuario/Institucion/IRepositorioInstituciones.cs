using Domain.Usuario;
using Domain.Taller;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Producto
{
    public interface IRepositorioInstituciones
    {
        List<Institucion> GetInstituciones();
        void RegistrarInstitucion(Institucion institucion);
        Institucion BuscarInstitucion(int Id);
        void EliminarInstitucion(int Id);
        int GetMaxIdInstituciones();
        void DonarProducto(Donacion.Donacion donacion, Institucion institucion);
        //bool GetProductoEnVenta(int id);
        //void PonerEnVenta(Producto producto);
        //List<Producto> GetProductosEnVenta();
        //void AsignarAInstitucion(Donacion.Donacion d, Institucion i);
        //Institucion BuscarInstitucion(int Id);
        //Taller.Taller BuscarTaller(int Id);
        //void RegistrarDestruccion(Producto p);
        //void AsignarATaller(Producto p, Taller.Taller t);
        //List<Taller.Taller> getTalleres();
        //List<Institucion> getInstituciones();
    }
}
