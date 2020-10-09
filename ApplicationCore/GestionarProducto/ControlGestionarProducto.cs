using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;
using Persistence.Repositories;

namespace ApplicationCore
{
    public class ControlGestionarProducto
    {
        IRepositorioGestionarProducto repo = new RepositorioGestionarProducto();
        public void RegistrarProducto(string descripcion, string marca, int tiempoDeUso, string categoria, string referencia)
        {
            int id = repo.GetMaxId()+1;
            Producto p = new Producto(id, descripcion, DateTime.Now, marca, tiempoDeUso, categoria, referencia);
            repo.RegistrarProducto(p);
        }

        public Producto GetProducto(int id)
        {
            try
            {
                return repo.GetProducto(id);
            }
            catch(ProductoNoExisteException ex)
            {
                throw ex;
            }
        }

        public List<Producto> GetAllProductos()
        {
            return repo.GetAllProductos();
        }
    }
}
