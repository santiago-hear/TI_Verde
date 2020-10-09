using Domain.Usuario;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Persistence.Repositories
{
    public class RepositorioRegistrarUsuario : IRepositorioRegistrarUsuario
    {
        readonly string pathUsuarios = @"..\Persistence\Data\Usuarios.json";
        public void registrarUsusario(Usuario usuario)
        {
            List<Usuario> usuarios;
            string usuariosString = File.ReadAllText(pathUsuarios);
            usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(usuariosString);
            Usuario us = usuarios.FirstOrDefault(u => u.Cedula == usuario.Cedula);
            if (us == null)
            {
                throw new UsuarioYaExisteException("El usuario con cedula" + usuario.Cedula + " ya se encuentra Registrado");
            }
            usuarios.Add(usuario);
            string jsonString = System.Text.Json.JsonSerializer.Serialize(usuarios);
            File.WriteAllText(pathUsuarios, jsonString);
        }

        public int GetMaxId()
        {
            int maxid = 0;
            List<Usuario> usuarios;
            string usuariosString = File.ReadAllText(pathUsuarios);
            usuarios = System.Text.Json.JsonSerializer.Deserialize<List<Usuario>>(usuariosString);
            foreach (Usuario p in usuarios)
            {
                if (p.Id > maxid)
                {
                    maxid = p.Id;
                }
            }
            return maxid;
        }

    }
}

