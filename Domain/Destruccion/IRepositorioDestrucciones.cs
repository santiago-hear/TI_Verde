using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Destruccion
{
    public interface IRepositorioDestrucciones
    {
        List<Destruccion> GetDestrucciones();
        void RegistrarDestruccion(Destruccion destruccion);
        Destruccion BuscarDestruccion(int Id);
        void EliminarDestruccion(int Id);
    }
}
