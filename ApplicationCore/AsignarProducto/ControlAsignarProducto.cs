using Domain.Usuario;
using Domain.Producto;
using Domain.Taller;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Destruccion;
using Domain.Donacion;

namespace ApplicationCore
{
    public class ControlAsignarProducto
    {
        readonly IRepositorioAsignarProducto repoAsignar = new RepositorioAsignarProducto();
        readonly IRepositorioGestionarProducto repoGestionar = new RepositorioGestionarProducto();
        public List<Producto> productos;
        public List<Institucion> instituciones;
        public List<Taller> talleres;
        public List<Destruccion> destrucciones;
        public ControlAsignarProducto()
        {
            productos = repoGestionar.GetAllProductos();
            talleres = repoAsignar.getTalleres();
            instituciones = repoAsignar.getInstituciones();
        }

        ////////////////////////////////////////// ASIGNACION A TALLER //////////////////////////////////////////////////////////

        /// <summary>
        /// Buscar los productos en estado 'compra' o 'aceptado'
        /// </summary>
        /// <returns> List<Taller> </returns>
        public List<Producto> DisponiblesParaTaller ()
        {
            return productos.FindAll(p => p.Estado.Equals("comprado") || p.Estado.Equals("aceptado"));
        }
        public List<Taller> GetTalleres()
        {
            return this.talleres;
        }
        public void AsignarProductoTaller(int IdTaller, int IdProducto)
        {
            try
            {
                //Producto producto = repoGestionar.GetProducto(IdProducto);
                Producto producto = productos.Find(p => IdProducto == p.Id);
                //Taller taller = repoAsignar.BuscarTaller(IdTaller);
                Taller taller = talleres.Find(t => IdTaller == t.Id);
                repoAsignar.AsignarATaller(producto, taller);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ////////////////////////////////////////// ASIGNACION A INSTITUCION //////////////////////////////////////////////////////////
        public List<Producto> DisponiblesParaInstitucion()
        {
            return productos.FindAll(p => p.Estado.Equals("reparado"));
        }
        public void AsignarProductoInstitucion(int IdInstitucion, int IdProducto)
        {
            try
            {
                //Producto producto = repoGestionar.GetProducto(IdProducto);
                Producto producto = productos.Find(p => IdProducto == p.Id);
                //Institucion institucion = repoAsignar.BuscarInstitucion(IdInstitucion);
                Institucion institucion = instituciones.Find(i => IdInstitucion == i.Id);
                Donacion donacion = new Donacion(1, "xx", producto, institucion);
                repoAsignar.AsignarAInstitucion(donacion, institucion);
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

    }
}
