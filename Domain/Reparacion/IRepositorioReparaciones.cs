using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Reparacion
{
    public interface IRepositorioReparaciones
    {
        List<Reparacion> GetReparaciones();
        void RegistrarReparacion(Reparacion reparacion);
        Reparacion BuscarReparacion(int id);
        void EliminarReparacion(int id);
        int GetMaxIdReparaciones();
    }
}
