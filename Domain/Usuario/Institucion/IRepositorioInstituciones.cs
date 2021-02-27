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
    }
}
