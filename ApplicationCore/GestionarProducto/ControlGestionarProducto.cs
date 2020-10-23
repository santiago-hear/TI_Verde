using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;
using Domain.TipoProducto;
using Persistence.Repositories;

namespace ApplicationCore
{
    public class ControlGestionarProducto
    {
        readonly IRepositorioGestionarProducto repositorioProductos;
        public List<Producto> productos;
        public ControlGestionarProducto()
        {
            repositorioProductos = new RepositorioGestionarProducto();
            productos = repositorioProductos.GetAllProductos();
        }
        public List<Producto> GetAllProductos()
        {
            return this.productos;
        }
        public void RegistrarProducto(string descripcion, string marca, int tiempoDeUso, TipoProducto categoria, string referencia)
        {
            int id = repositorioProductos.GetMaxId()+1;
            Producto p = new Producto(id, descripcion, DateTime.Now, marca, tiempoDeUso, categoria, referencia);
            repositorioProductos.RegistrarProducto(p);
        }
        public Producto GetProducto(int id)
        {
            try
            {
                return repositorioProductos.GetProducto(id);
            }
            catch(ProductoNoExisteException ex)
            {
                throw ex;
            }
        }

        
    }
}
