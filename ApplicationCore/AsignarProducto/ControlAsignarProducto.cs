using Domain.Usuario;
using Domain.Producto;
using Domain.Taller;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using Domain.Destruccion;
using Domain.Donacion;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace ApplicationCore.AsignarProducto
{
    public class ControlAsignarProducto
    {
        readonly IRepositorioProductos repositorioProductos;
        readonly IRepositorioTalleres repositorioTalleres;
        readonly IRepositorioInstituciones repositorioInstituciones;
        readonly IRepositorioDonaciones repositorioDonaciones;
        readonly IRepositorioDestrucciones repositorioDestrucciones;
        public ControlAsignarProducto()
        {
            repositorioProductos = new RepositorioProductos();
            repositorioTalleres = new RepositorioTalleres();
            repositorioInstituciones = new RepositorioInstituciones();
            repositorioDonaciones = new RepositorioDonaciones();
            repositorioDestrucciones = new RepositorioDestrucciones();
        }

        ////////////////////////////////////////// ASIGNACION A TALLER //////////////////////////////////////////////////////////
        
        public List<Producto> DisponiblesParaTaller ()
        {
            try
            {
                List<Producto> productos = repositorioProductos.GetProductos();
                return productos.FindAll(p => p.Estado.Equals("Comprado") || p.Estado.Equals("Aceptado"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<Taller> GetTalleres()
        {
            try
            {
                List<Taller> talleres = repositorioTalleres.GetTalleres();
                return talleres;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void AsignarProductoTaller(int IdTaller, int IdProducto)
        {
            try
            {
                string estado = "En Taller";
                Producto producto = repositorioProductos.BuscarProducto(IdProducto);
                Producto productoActualizado = producto;
                Taller taller = repositorioTalleres.BuscarTaller(IdTaller);
                productoActualizado.Estado = estado;
                repositorioProductos.ActualizarProducto(producto, productoActualizado);
                repositorioTalleres.AsignarProducto(producto, taller);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        ////////////////////////////////////////// ASIGNACION A INSTITUCION //////////////////////////////////////////////////////////
        
        public List<Producto> DisponiblesParaInstitucion()
        {
            try
            {
                List<Producto> productos = repositorioProductos.GetProductos();
                return productos.FindAll(p => p.Estado.Equals("Reparado Con Fallas"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public List<Institucion> GetInstituciones()
        {
            try
            {
                List<Institucion> instituciones = repositorioInstituciones.GetInstituciones();
                return instituciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public void AsignarProductoInstitucion(int IdInstitucion, int IdProducto, string descripcionDonacion)
        {
            try
            {
                int newId = repositorioDonaciones.GetMaxIdDonaciones() + 1;
                string estado = "Donado";
                Producto producto = repositorioProductos.BuscarProducto(IdProducto);
                Producto productoActualizado = producto;
                productoActualizado.Estado = estado;
                Institucion institucion = repositorioInstituciones.BuscarInstitucion(IdInstitucion);
                Donacion donacion = new Donacion(newId, descripcionDonacion, producto);
                repositorioProductos.ActualizarProducto(producto, productoActualizado);
                repositorioInstituciones.DonarProducto(donacion, institucion);
                repositorioDonaciones.RegistrarDonacion(donacion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        ////////////////////////////////////////// ASIGNACION PARA DESTRUCCION //////////////////////////////////////////////////////////

        public List<Producto> DisponiblesParaDestruccion()
        {
            try
            {
                List<Producto> productos = repositorioProductos.GetProductos();
                return productos.FindAll(p => p.Estado.Equals("Sin Arreglo"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void AsignarProductoDestruccion(string descripcionDestruccion, string imagenPrueba, int IdProducto)
        {
            try
            {
                int newId = repositorioDestrucciones.GetMaxIdDestrucciones() + 1;
                string estado = "Destruido";
                Producto producto = repositorioProductos.BuscarProducto(IdProducto);
                Producto productoActualizado = producto;
                productoActualizado.Estado = estado;
                Destruccion destruccion = new Destruccion(newId, descripcionDestruccion, DateTime.Now, imagenPrueba, producto);
                repositorioProductos.ActualizarProducto(producto, productoActualizado);
                repositorioDestrucciones.RegistrarDestruccion(destruccion);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
