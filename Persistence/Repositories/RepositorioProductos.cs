﻿using System;
using System.Collections.Generic;
using System.IO;
using Domain.Producto;
using System.Linq;
using Domain.Usuario;

namespace Persistence.Repositories
{
    public class RepositorioProductos : IRepositorioProductos
    {
        readonly string pathProductos = @"..\Persistence\Data\Productos.json";
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
            try
            {
                Producto producto = productos.Find(p => p.Id == id);
                if (producto == null)
                {
                    throw new ProductoNoExisteException("El producto con id: " + id + "no se puede eliminar porque no existe");
                }
                productos.Remove(producto);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(productos);
                File.WriteAllText(pathProductos, jsonString);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarProducto(Producto productoAntiguo, Producto productoNuevo)
        {
            try
            {
                Producto producto = productos.Find(p => p.Id == productoAntiguo.Id);
                if (producto == null)
                {
                    throw new ProductoNoExisteException("El producto con id: " + productoAntiguo.Id + " no existe");
                }
                productos.Remove(producto);
                productos.Add(productoNuevo);
                productos.Sort((x, y) => x.Id.CompareTo(y.Id));
                string jsonString = System.Text.Json.JsonSerializer.Serialize(productos);
                File.WriteAllText(pathProductos, jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetMaxIdProductos()
        {
            int maxid = 0;
            foreach (Producto producto in productos)
            {
                if (producto.Id > maxid)
                {
                    maxid = producto.Id;
                }
            }
            return maxid;
        }
    }
}
