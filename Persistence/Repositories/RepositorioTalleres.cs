using Domain.Producto;
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
        }

        public void AsignarProducto(Producto producto, Taller taller)
        {
            talleres = System.Text.Json.JsonSerializer.Deserialize<List<Taller>>(talleresString);
            foreach (Taller t in talleres)
            {
                if (taller.Id == t.Id)
                {
                    taller.Asignaciones.Add(producto);
                }
            }
            jsonString = System.Text.Json.JsonSerializer.Serialize(talleres);
            File.WriteAllText(pathTalleres, jsonString);
        }

        public Taller BuscarTaller(int Id)
        {
            talleres = System.Text.Json.JsonSerializer.Deserialize<List<Taller>>(talleresString);
            Taller taller = talleres.FirstOrDefault(p => p.Id == Id);

            if (taller == null)
            {
                throw new AsignacionIncorrectaException("El taller con id: " + Id + " no existe");
            }
            return taller;
        }

        public void EliminarTaller(int id)
        {
            throw new NotImplementedException();
        }

        public List<Taller> GetTalleres()
        {
            talleres = System.Text.Json.JsonSerializer.Deserialize<List<Taller>>(talleresString);
            return talleres;
        }

        public void RegistrarTaller(Taller taller)
        {
            talleres = System.Text.Json.JsonSerializer.Deserialize<List<Taller>>(talleresString);
            talleres.Add(taller);
            jsonString = System.Text.Json.JsonSerializer.Serialize(talleres);
            File.WriteAllText(pathTalleres, jsonString);
        }
    }
}
