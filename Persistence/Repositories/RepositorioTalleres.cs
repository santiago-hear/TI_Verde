using Domain.Producto;
using Domain.Reparacion;
using Domain.Taller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Persistence.Repositories
{
    public class RepositorioTalleres : IRepositorioTalleres
    {
        readonly string pathTalleres = @"..\Persistence\Data\Talleres.json";
        readonly string talleresString;
        string jsonString;
        private List<Taller> talleres;

        public RepositorioTalleres()
        {
            talleresString = File.ReadAllText(pathTalleres);
            talleres = System.Text.Json.JsonSerializer.Deserialize<List<Taller>>(talleresString);
        }

        public void AsignarProducto(Producto producto, Taller taller)
        {
            foreach (Taller t in talleres)
            {
                if (taller.Id == t.Id)
                {
                    t.Asignaciones.Add(producto);
                }
            }
            jsonString = System.Text.Json.JsonSerializer.Serialize(talleres);
            File.WriteAllText(pathTalleres, jsonString);
        }

        public Taller BuscarTaller(int Id)
        {
            Taller taller = talleres.FirstOrDefault(p => p.Id == Id);

            if (taller == null)
            {
                throw new TallerNoExisteException("El taller con id: " + Id + " no existe");
            }
            return taller;
        }

        public void EliminarTaller(int id)
        {
            throw new NotImplementedException();
        }

        public int GetMaxIdTalleres()
        {
            int maxid = 0;
            foreach (Taller taller in talleres)
            {
                if (taller.Id > maxid)
                {
                    maxid = taller.Id;
                }
            }
            return maxid;
        }

        public List<Taller> GetTalleres()
        {
            return talleres;
        }
        public void RegistrarTaller(Taller taller)
        {
            talleres.Add(taller);
            jsonString = System.Text.Json.JsonSerializer.Serialize(talleres);
            File.WriteAllText(pathTalleres, jsonString);
        }

        public List<Producto> GetAsignaciones(int id)
        {
            try
            {
                return BuscarTaller(id).Asignaciones;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<Reparacion> GetReparaciones(int id)
        {
            try
            {
                return this.BuscarTaller(id).Reparaciones;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void RegistrarReparacion(Reparacion reparacion, int id)
        {
            try
            {
                foreach (Taller t in talleres)
                {
                    if (id == t.Id)
                    {
                        t.Reparaciones.Add(reparacion);
                    }
                }
                Taller taller = talleres.FirstOrDefault(t => t.Id == id);
                Taller tallerN = taller;
                talleres.Remove(taller);
                List<Producto> asignaciones = tallerN.Asignaciones;
                Producto producto = asignaciones.FirstOrDefault(p => p.Id == reparacion.ProductoReparado.Id);
                asignaciones.Remove(producto);
                producto.Estado = "Reparado";
                asignaciones.Add(producto);
                tallerN.Asignaciones = asignaciones;
                talleres.Add(tallerN);
                jsonString = System.Text.Json.JsonSerializer.Serialize(talleres);
                File.WriteAllText(pathTalleres, jsonString);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
