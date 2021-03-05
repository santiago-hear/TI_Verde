using System;
using System.Collections.Generic;
using Domain.Producto;
using Domain.Taller;
using Persistence.Repositories;

namespace ApplicationCore.GestionAsignacion
{
    public class ControlGestionarAsignaciones
    {
        readonly IRepositorioTalleres repositorioTalleres;
        public ControlGestionarAsignaciones()
        {
            repositorioTalleres = new RepositorioTalleres();
        }
        public List<Producto> GetProductosAsignados(int id)
        {
            try
            {
                return repositorioTalleres.GetAsignaciones(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
    }
}
