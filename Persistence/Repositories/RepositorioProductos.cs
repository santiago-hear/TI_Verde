using System;
using System.Collections.Generic;
using System.IO;
using Domain.Producto;
using System.Linq;
using Domain.TipoProducto;

namespace Persistence.Repositories
{
    public class RepositorioProductos : IRepositorioProductos
    {
        readonly string pathProductos = @"..\Persistence\Data\productos.json";
        string productosString;
        private List<Producto> productos;

        public RepositorioProductos()
        {
            try
            {
                productosString = File.ReadAllText(pathProductos);
                productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Producto> GetProductos()
        {
            return productos;
        }
        public void RegistrarProducto(Producto producto)
        {
            try
            {
                productos.Add(producto);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(productos);
                File.WriteAllText(pathProductos, jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Producto BuscarProducto(int id)
        {
            Producto producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                throw new ProductoNoExisteException("El producto con id: " + id + " no existe");
            }
            return producto;
        }

        public void EliminarProducto(int id)
        {
            throw new NotImplementedException();
        }

        public void ActualizarEstado(Producto producto, string estado)
        {
            try
            {
                productos.Find(p => p.Id == producto.Id).Estado = estado;
                string jsonString = System.Text.Json.JsonSerializer.Serialize(productos);
                File.WriteAllText(pathProductos, jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public List<Producto> ObtenerInforme(DateTime mes)
        //{
        //    List<Producto> productosDevuelta =  new List<Producto>();
        //    string productosString = File.ReadAllText(pathProductos);
        //    productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
        //    for (int i = 0; i < productos.Count; i++)
        //    {
        //        Producto product = productos[i];

        //        if (product.FechaIngreso.Month == mes.Month) {
        //            productosDevuelta.Add(product);
        //        }
        //    }

        //    if (productosDevuelta.Count() == 0)
        //    {
        //        throw new NoHayProductosMesException("No hay productos registrados para el mes: " + mes.Month);
        //    }
        //    return productosDevuelta;
        //}
    }
}
