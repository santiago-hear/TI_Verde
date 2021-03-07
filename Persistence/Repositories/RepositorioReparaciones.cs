using Domain.Reparacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Persistence.Repositories
{
    public class RepositorioReparaciones : IRepositorioReparaciones
    {
        readonly string pathReparaciones = @"..\Persistence\Data\Reparaciones.json";
        readonly private List<Reparacion> reparaciones;

        public RepositorioReparaciones()
        {
            string reparacionesString;
            try
            {
                reparacionesString = File.ReadAllText(pathReparaciones);
                reparaciones = System.Text.Json.JsonSerializer.Deserialize<List<Reparacion>>(reparacionesString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<Reparacion> GetReparaciones()
        {
            return reparaciones;
        }

        public void RegistrarReparacion(Reparacion reparacion)
        {
            try
            {
                reparaciones.Add(reparacion);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(reparaciones);
                File.WriteAllText(pathReparaciones, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public Reparacion BuscarReparacion(int Id)
        {
            Reparacion reparacion = reparaciones.FirstOrDefault(p => p.Id == Id);
            if (reparacion == null)
            {
                throw new ReparacionNoExisteException("La reparacion con id: " + Id + " no existe");
            }
            return reparacion;
        }

        public void EliminarReparacion(int Id)
        {
            try
            {
                Reparacion institucion = reparaciones.Find(p => p.Id == Id);
                if (institucion == null)
                {
                    throw new ReparacionNoExisteException("La Reparacion con id: " + Id + "no se puede eliminar porque no existe");
                }
                reparaciones.Remove(institucion);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(reparaciones);
                File.WriteAllText(pathReparaciones, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int GetMaxIdReparaciones()
        {
            int maxid = 0;
            foreach (Reparacion reparacion in reparaciones)
            {
                if (reparacion.Id > maxid)
                {
                    maxid = reparacion.Id;
                }
            }
            return maxid;
        }
    }
}
