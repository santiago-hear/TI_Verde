using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Taller
{
    public interface IRepositorioTalleres
    {
        List<Taller> GetTalleres();
        void RegistrarTaller(Taller taller);
        Taller BuscarTaller(int id);
        void EliminarTaller(int id);
        int GetMaxIdTalleres();
        void AsignarProducto(Producto.Producto producto, Taller taller);
        List<Producto.Producto> GetAsignaciones(int id);
        List<Reparacion.Reparacion> GetReparaciones(int id);
        void RegistrarReparacion(Reparacion.Reparacion reparacion, int id);

    }
}
