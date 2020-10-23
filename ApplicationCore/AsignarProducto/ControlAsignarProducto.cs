using Domain.Usuario;
using Domain.Producto;
using Domain.Taller;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
    public class ControlAsignarProducto
    {
        readonly IRepositorioAsignarProducto repoAsignar = new RepositorioAsignarProducto();
        readonly IRepositorioGestionarProducto repoGestionar = new RepositorioGestionarProducto();

        public void AsignarProductoInstitucion(int IdInstitucion, int IdProducto)
        {
            try
            {
                Producto producto = repoGestionar.GetProducto(IdProducto);
                Institucion institucion = repoAsignar.BuscarInstitucion(IdInstitucion);
                repoAsignar.AsignarAInstitucion(producto, institucion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void AsignarProductoTaller(int IdTaller, int IdProducto)
        {
            try
            {
                Producto producto = repoGestionar.GetProducto(IdProducto);
                Taller taller = repoAsignar.BuscarTaller(IdTaller);
                repoAsignar.AsignarATaller(producto, taller);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Institucion> GetInstituciones()
        {
            return repoAsignar.getInstituciones();
        }
        public List<Taller> GetTalleres()
        {
            return repoAsignar.getTalleres();
        }

    }
}
