using System;
using System.Collections.Generic;
using Domain.Producto;
using Domain.TipoProducto;
using Domain.Usuario;
using Persistence.Repositories;

namespace ApplicationCore
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
                throw ex;
            }
            
        }

        public void RegistrarProducto(string descripcion, string marca, int tiempoDeUso, int Idcategoria, string referencia)
        {
            try
            {
                int newId = repositorioProductos.GetMaxIdProductos() + 1;
                TipoProducto categoria = repositorioTiposProductos.BuscarTipoProducto(Idcategoria);
                Producto p = new Producto(newId, descripcion, DateTime.Now, marca, tiempoDeUso, categoria, referencia);
                repositorioProductos.RegistrarProducto(p);
            }
            catch(Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }
    }
}
