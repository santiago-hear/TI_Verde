using System;
using System.Collections.Generic;
using System.Text;
using Domain.Producto;
using Domain.TipoProducto;
using Newtonsoft.Json.Linq;
using Persistence.Repositories;

namespace ApplicationCore.ConfigurarTipoProducto
{
    public class ControlConfigurarTipoProducto
    {
        readonly IRepositorioTiposProductos repositorioTiposProductos;

        public ControlConfigurarTipoProducto()
        {
            repositorioTiposProductos = new RepositorioTiposProductos();
        }
        public List<TipoProducto> GetTiposProductosConfigurados()
        {
            try
            {
                List<TipoProducto> tiposProductos = repositorioTiposProductos.GetTiposProductosConfigurados();
                return tiposProductos;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public List<List<string>> GetTiposProductos()
        {
            try    
            {
                List<dynamic> inventarioJSON = repositorioTiposProductos.GetTiposProductosInventario();
                List<List<string>> inventario = new List<List<string>>();
                foreach (dynamic d in inventarioJSON)
                {
                    JObject item = JObject.Parse(d.ToString());
                    string Nombre = (string)item["Nombre"];
                    string Descripcion = (string)item["Descripcion"];
                    List<string> tipo = new List<string> { Nombre, Descripcion };
                    inventario.Add(tipo);
                }
                return inventario;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void ConfigurarTiposProductos(List<dynamic> TiposProductos) 
        {    
            try
            {
                foreach(dynamic t in TiposProductos)
                {
                    int newId = repositorioTiposProductos.GetMaxIdTiposProductos();
                    Console.WriteLine("Nombre: ", t[0], " Descripcion: ",t[1]);
                    TipoProducto tipo = new TipoProducto(newId, t[0], t[1]);
                    repositorioTiposProductos.RegistrarTipoProducto(tipo);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
