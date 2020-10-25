using Domain.Destruccion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Persistence.Repositories
{
    public class RepositorioDestrucciones : IRepositorioDestrucciones
    {
        readonly string pathDestrucciones = @"..\Persistence\Data\Destrucciones.json";
        string destruccionesString;
        private List<Destruccion> destrucciones;

        public RepositorioDestrucciones()
        {
            try
            {
                destruccionesString = File.ReadAllText(pathDestrucciones);
                destrucciones = System.Text.Json.JsonSerializer.Deserialize<List<Destruccion>>(destruccionesString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Destruccion> GetDestrucciones()
        {
            return destrucciones;
        }

        public void RegistrarDestruccion(Destruccion destruccion)
        {
            try
            {
                destrucciones.Add(destruccion);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(destrucciones);
                File.WriteAllText(pathDestrucciones, jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Destruccion BuscarDestruccion(int id)
        {
            Destruccion destruccion = destrucciones.FirstOrDefault(p => p.Id == id);
            if (destruccion == null)
            {
                //throw new DestruccionNoExisteException("La destruccion con id: " + id + " no existe");
            }
            return destruccion;
        }

        public void EliminarDestruccion(int id)
        {
            throw new NotImplementedException();
        }
    }
}
