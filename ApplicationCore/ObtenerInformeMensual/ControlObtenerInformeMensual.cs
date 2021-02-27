using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;
using Persistence.Repositories;

namespace ApplicationCore
{
    public class ControlObtenerInformeMensual
    {
        readonly IRepositorioProductos repositorioProductos = new RepositorioProductos();

        public List<Producto> ObtenerInformeMensualProductos(DateTime fecha)
        {
            try
            {
                List<Producto> productos = repositorioProductos.GetProductos();
                List<Producto> informe = productos.FindAll(p => p.FechaIngreso.Date.Month == fecha.Month);
                return informe;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
