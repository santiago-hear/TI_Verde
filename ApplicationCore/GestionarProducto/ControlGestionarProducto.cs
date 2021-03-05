using System;
using System.Collections.Generic;
using Domain.Producto;
using Domain.TipoProducto;
using Domain.Usuario;
using Persistence.Repositories;

namespace ApplicationCore.GestionarProducto
{
    public class ControlGestionarProducto
    {
        readonly IRepositorioProductos repositorioProductos;
        readonly IRepositorioTiposProductos repositorioTiposProductos;
        public ControlGestionarProducto()
        {
            repositorioProductos = new RepositorioProductos();
            repositorioTiposProductos = new RepositorioTiposProductos();
        }
        public List<Producto> GetProductos()
        {
            try
            {
                return repositorioProductos.GetProductos();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }

        public List<TipoProducto> GetTiposProductos()
        {
            try
            {
                return repositorioTiposProductos.GetTiposProductosConfigurados();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public void RegistrarProducto(string descripcion, string marca, int tiempoDeUso, int Idcategoria, string referencia)
        {
            try
            {
                int newId = repositorioProductos.GetMaxIdProductos() + 1;
                TipoProducto categoria = repositorioTiposProductos.BuscarTipoProducto(Idcategoria);
                Console.WriteLine(categoria);
                Producto p = new Producto(newId, descripcion, DateTime.Now, marca, tiempoDeUso, categoria, referencia);
                repositorioProductos.RegistrarProducto(p);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Producto BuscarProducto(int IdProducto)
        {
            try
            {
                return repositorioProductos.BuscarProducto(IdProducto);
            }
            catch (InstitucionNoExisteException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
