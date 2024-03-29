﻿using System;
using System.Collections.Generic;
using System.IO;
using Domain.Producto;
using Domain.Usuario;
using System.Linq;
using Domain.Donacion;

namespace Persistence.Repositories
{
    public class RepositorioInstituciones : IRepositorioInstituciones
    {
        readonly string pathInstituciones = @"..\Persistence\Data\Instituciones.json";
        string jsonString;
        private List<Institucion> instituciones;

        public RepositorioInstituciones()
        {
            string institucionesString;
            try
            {
                institucionesString = File.ReadAllText(pathInstituciones);
                instituciones = System.Text.Json.JsonSerializer.Deserialize<List<Institucion>>(institucionesString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            institucionesString = File.ReadAllText(pathInstituciones);
        }

        public List<Institucion> GetInstituciones()
        {
            return instituciones;
        }

        public Institucion BuscarInstitucion(int Id)
        {
            Institucion institucion = instituciones.FirstOrDefault(p => p.Id == Id);
            if (institucion == null)
            {
                throw new InstitucionNoExisteException("La institucion con id: " + Id + " no existe");
            }
            return institucion;
        }

        public void RegistrarInstitucion(Institucion institucion)
        {
            try
            {
                instituciones.Add(institucion);
                jsonString = System.Text.Json.JsonSerializer.Serialize(instituciones);
                File.WriteAllText(pathInstituciones, jsonString);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarInstitucion(int IdInstitucion)
        {
            try
            {
                Institucion institucion = instituciones.Find(p => p.Id == IdInstitucion);
                if (institucion == null)
                {
                    throw new InstitucionNoExisteException("La Institucion con id: " + IdInstitucion + "no se puede eliminar porque no existe");
                }
                instituciones.Remove(institucion);
                string jsonString = System.Text.Json.JsonSerializer.Serialize(instituciones);
                File.WriteAllText(pathInstituciones, jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DonarProducto(Donacion donacion, Institucion institucion)
        {
            Institucion producto = instituciones.Find(p => p.Id == institucion.Id);
            if (producto == null)
            {
                throw new InstitucionNoExisteException("La Institucion con id: " + institucion.Id + "no existe");
            }
            try
            {
                jsonString = System.Text.Json.JsonSerializer.Serialize(instituciones);
                File.WriteAllText(pathInstituciones, jsonString);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int GetMaxIdInstituciones()
        {
            int maxid = 0;
            foreach (Institucion institucion in instituciones)
            {
                if (institucion.Id > maxid)
                {
                    maxid = institucion.Id;
                }
            }
            return maxid;
        }
    }
}
