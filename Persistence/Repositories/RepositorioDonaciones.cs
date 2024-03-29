﻿using Domain.Donacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Persistence.Repositories
{
    public class RepositorioDonaciones : IRepositorioDonaciones
    {
        readonly string pathDonaciones = @"..\Persistence\Data\Donaciones.json";
        readonly private List<Donacion> donaciones;

        public RepositorioDonaciones()
        {
            string donacionesString;
            try
            {
                donacionesString = File.ReadAllText(pathDonaciones);
                donaciones = System.Text.Json.JsonSerializer.Deserialize<List<Donacion>>(donacionesString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
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
                Console.WriteLine(ex);
                throw;
            }
        }
        public Donacion BuscarDonacion(int Id)
        {
            Donacion donacion = donaciones.FirstOrDefault(p => p.Id == Id);
            if (donacion == null)
            {
                throw new DonacionNoExisteException(" donacion con id: " + Id + " no existe");
            }
            return donacion;
        }

        public void EliminarDonacion(int Id)
        {
            try
            {
                Donacion donacion = donaciones.Find(p => p.Id == Id);
                if (donacion == null)
                {
                    throw new DonacionNoExisteException("La Donacion con id: " + Id + "no se puede eliminar porque no existe");
                }
                donaciones.Remove(donacion);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(donaciones);
                File.WriteAllText(pathDonaciones, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
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
