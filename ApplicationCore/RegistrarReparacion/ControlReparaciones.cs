using Domain.Producto;
using Domain.Reparacion;
using Domain.Taller;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.RegistrarReparacion
{
    public class ControlReparaciones
    {
        readonly IRepositorioTalleres repositorioTalleres;
        readonly IRepositorioReparaciones repositorioReparaciones;
        readonly IRepositorioProductos repositorioProductos;
        public ControlReparaciones()
        {
            repositorioTalleres = new RepositorioTalleres();
            repositorioReparaciones = new RepositorioReparaciones();
            repositorioProductos = new RepositorioProductos();
        }
        public void RegistrarReparacion(string Descripcion, int ProductId, int tallerId, float Costo, string rutaImagen)
        {
            try
            {
                DateTime fecha = DateTime.Now;
                int id = repositorioReparaciones.GetMaxIdReparaciones() + 1;
                Producto p = repositorioProductos.BuscarProducto(ProductId);
                Producto pn = p;
                pn.Estado = "Reparado";
                repositorioProductos.ActualizarProducto(p, pn);
                Reparacion rep = new Reparacion(id, Descripcion, Costo, fecha, pn, rutaImagen);
                repositorioReparaciones.RegistrarReparacion(rep);
                repositorioTalleres.RegistrarReparacion(rep, tallerId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public List<Reparacion> GetReparaciones(int tallerId)
        {
            try
            {
                return repositorioTalleres.GetReparaciones(tallerId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public List<Producto> GetProductosParaReparar(int tallerId)
        {
            try
            {
                List<Producto> productos = repositorioTalleres.GetAsignaciones(tallerId);
                return productos.FindAll(p => p.Estado.ToLower() == "Taller".ToLower());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
