using Domain.TipoProducto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Persistence.Repositories
{
    public class RepositorioTiposProductos : IRepositorioTiposProductos
    {
        readonly string pathTiposProductos = @"..\Persistence\Data\TiposProductos.json";
        readonly string pathInventario = @"..\Persistence\Data\Inventario.json";

        string tiposProductosString;
        string inventarioString;
        private List<TipoProducto> tiposProductos;
        private List<dynamic> inventario;

        public RepositorioTiposProductos()
        {
            try
            {
                tiposProductosString = File.ReadAllText(pathTiposProductos);
                tiposProductos = System.Text.Json.JsonSerializer.Deserialize<List<TipoProducto>>(tiposProductosString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TipoProducto> GetTiposProductosConfigurados()
        {
            return tiposProductos;
        }

        public void RegistrarTipoProducto(TipoProducto tipoProducto)
        {
            try
            {
                tiposProductos.Add(tipoProducto);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(tiposProductos);
                File.WriteAllText(pathTiposProductos, jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TipoProducto BuscarTipoProducto(int id)
        {
            TipoProducto tipoProducto = tiposProductos.FirstOrDefault(p => p.Id == id);
            if (tipoProducto == null)
            {
                throw new TipoProductoNoExisteException("El tipoProducto con id: " + id + " no existe");
            }
            return tipoProducto;
        }

        public void EliminarTipoProducto(int id)
        {
            throw new NotImplementedException();
        }

        public int GetMaxIdTiposProductos()
        {
            int maxid = 0;
            foreach (TipoProducto tipoProducto in tiposProductos)
            {
                if (tipoProducto.Id > maxid)
                {
                    maxid = tipoProducto.Id;
                }
            }
            return maxid;
        }

        public List<dynamic> GetTiposProductosInventario()
        {
            try
            {
                inventarioString = File.ReadAllText(pathInventario);
                inventario = System.Text.Json.JsonSerializer.Deserialize<List<dynamic>>(inventarioString);
                return inventario;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
