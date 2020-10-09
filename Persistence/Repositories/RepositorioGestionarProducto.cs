using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Domain.Producto;
using System.Linq;

namespace Persistence.Repositories
{
    public class RepositorioGestionarProducto : IRepositorioGestionarProducto
    {
        string pathProductos = @"..\Persistence\Data\productos.json";
        public void RegistrarProducto(Producto producto)
        {
            List<Producto> productos;
            string productosString = File.ReadAllText(pathProductos);
            productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
            productos.Add(producto);
            string jsonString = System.Text.Json.JsonSerializer.Serialize(productos);
            File.WriteAllText(pathProductos, jsonString);
        }

        public int GetMaxId()
        {
            int maxid = 0;
            List<Producto> productos;
            string productosString = File.ReadAllText(pathProductos);
            productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
            foreach (Producto p in productos)
            {
                if (p.Id > maxid)
                {
                    maxid = p.Id;
                }
            }
            return maxid;
        }

        public Producto GetProducto(int id)
        {
            List<Producto> productos;
            string productosString = File.ReadAllText(pathProductos);
            productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
            Producto producto = productos.FirstOrDefault(p => p.Id == id);

            if (producto == null)
            {
                throw new ProductoNoExisteException("El producto con id: " + id + " no existe");
            }
            return producto;
        }

        public List<Producto> GetAllProductos()
        {
            List<Producto> productos;
            string productosString = File.ReadAllText(pathProductos);
            productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);

            return productos;
        }

        public List<Producto> ObtenerInforme(DateTime mes)
        {
            List<Producto> productos;
            List<Producto> productosDevuelta =  new List<Producto>();
            string productosString = File.ReadAllText(pathProductos);
            productos = System.Text.Json.JsonSerializer.Deserialize<List<Producto>>(productosString);
            for (int i = 0; i < productos.Count; i++)
            {
                Producto product = productos[i];

                if (product.FechaIngreso.Month == mes.Month) {
                    productosDevuelta.Add(product);
                }
            }
            
            if (productosDevuelta.Count() == 0)
            {
                throw new NoHayProductosMesException("No hay productos registrados para el mes: " + mes.Month);
            }
            return productosDevuelta;
        }
    }
}
