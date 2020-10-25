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
        readonly IRepositorioProductos repositorioProductos;
        readonly IRepositorioTalleres repositorioTalleres;
        readonly IRepositorioInstituciones repositorioInstituciones;
        readonly IRepositorioDestrucciones repositorioDonaciones;
        public ControlAsignarProducto()
        {
            repositorioProductos = new RepositorioProductos();
            repositorioTalleres = new RepositorioTalleres();
            repositorioInstituciones = new RepositorioInstituciones();
            repositorioDonaciones = new RepositorioDonaciones();
        }

        ////////////////////////////////////////// ASIGNACION A TALLER //////////////////////////////////////////////////////////
        
        public List<Producto> DisponiblesParaTaller ()
        {
            List<Producto> productos = repositorioProductos.GetProductos();
            return productos.FindAll(p => p.Estado.Equals("comprado") || p.Estado.Equals("aceptado"));
        }
        public List<Taller> GetTalleres()
        {
            List<Taller> talleres = repositorioTalleres.GetTalleres();
            return talleres;
        }
        public void AsignarProductoTaller(int IdTaller, int IdProducto)
        {
            try
            {
                string estado = "en Taller";
                Producto producto = repositorioProductos.BuscarProducto(IdProducto);
                Taller taller = repositorioTalleres.BuscarTaller(IdTaller);
                repositorioProductos.ActualizarEstado(producto ,estado);
                producto.Estado = estado;
                repositorioTalleres.AsignarProducto(producto, taller);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////////////////////////////////////////// ASIGNACION A INSTITUCION //////////////////////////////////////////////////////////
        
        public List<Producto> DisponiblesParaInstitucion()
        {
            List<Producto> productos = repositorioProductos.GetProductos();
            return productos.FindAll(p => p.Estado.Equals("reparado"));
        }
        public List<Institucion> GetInstituciones()
        {
            List<Institucion> instituciones = repositorioInstituciones.GetInstituciones();
            return instituciones;
        }
        public void AsignarProductoInstitucion(int IdInstitucion, int IdProducto, string descripcionDonacion)
        {
            try
            {
                string estado = "donado";
                Producto producto = repositorioProductos.BuscarProducto(IdProducto);
                producto.Estado = estado;
                Institucion institucion = repositorioInstituciones.BuscarInstitucion(IdInstitucion);
                Donacion donacion = new Donacion(1, descripcionDonacion, producto);
                repositorioProductos.ActualizarEstado(producto, estado);
                repositorioInstituciones.DonarProducto(donacion, institucion);
                repositorioDonaciones.RegistrarDonacion(donacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////////////////////////////////////////// ASIGNACION PARA DESTRUCCION //////////////////////////////////////////////////////////
        
        public void AsignarProductoDestruccion(string descripcionDestruccion, string imagenPrueba, int IdProducto)
        {
            try
            {
                string estado = "destruido";
                Producto producto = repositorioProductos.BuscarProducto(IdProducto);
                producto.Estado = estado;
                Destruccion destruccion = new Destruccion(1, descripcionDestruccion, DateTime.Now, imagenPrueba, producto);
                repositorioProductos.ActualizarEstado(producto, estado);
                repositorioDestrucciones.RegistrarDestruccion(destruccion);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
