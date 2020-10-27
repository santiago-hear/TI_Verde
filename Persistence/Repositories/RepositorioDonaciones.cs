using Domain.Donacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Persistence.Repositories
{
    public class RepositorioDonaciones : IRepositorioDonaciones
    {
        readonly string pathDonaciones = @"..\Persistence\Data\Donaciones.json";
        string donacionesString;
        private List<Donacion> donaciones;

        public RepositorioDonaciones()
        {
            try
            {
                donacionesString = File.ReadAllText(pathDonaciones);
                donaciones = System.Text.Json.JsonSerializer.Deserialize<List<Donacion>>(donacionesString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Donacion> GetDonaciones()
        {
            return donaciones;
        }

        public void RegistrarDonacion(Donacion donacion)
        {
            try
            {
                donaciones.Add(donacion);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(donaciones);
                File.WriteAllText(pathDonaciones, jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Donacion BuscarDonacion(int id)
        {
            Donacion donacion = donaciones.FirstOrDefault(p => p.Id == id);
            if (donacion == null)
            {
                throw new DonacionNoExisteException(" donacion con id: " + id + " no existe");
            }
            return donacion;
        }

        public void EliminarDonacion(int IdDonacion)
        {
            try
            {
                Donacion donacion = donaciones.Find(p => p.Id == IdDonacion);
                if (donacion == null)
                {
                    throw new DonacionNoExisteException("La Donacion con id: " + IdDonacion + "no se puede eliminar porque no existe");
                }
                donaciones.Remove(donacion);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(donaciones);
                File.WriteAllText(pathDonaciones, jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetMaxIdDonaciones()
        {
            int maxid = 0;
            foreach (Donacion donacion in donaciones)
            {
                if (donacion.Id > maxid)
                {
                    maxid = donacion.Id;
                }
            }
            return maxid;
        }
    }
}
