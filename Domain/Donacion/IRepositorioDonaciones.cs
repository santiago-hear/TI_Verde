using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Donacion
{
    public interface IRepositorioDonaciones
    {
        List<Donacion> GetDonaciones();
        void RegistrarDonacion(Donacion donacion);
        Donacion BuscarDonacion(int Id);
        void EliminarDonacion(int Id);
    }
}
