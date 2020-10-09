using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;
using Persistence.Repositories;

namespace ApplicationCore
{
    public class ControlObtenerInformeMensual
    {
        readonly IRepositorioGestionarProducto repo = new RepositorioGestionarProducto();
        public List<Producto> ObtenerInformeProductosMensual(DateTime fecha)
        {
            try
            {
                return repo.ObtenerInforme(fecha);
            }
            catch(NoHayProductosMesException ex)
            {
                throw ex;
            }
        }
    }
}
