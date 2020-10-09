using System;
using System.Collections.Generic;
using System.Text;
using Domain.Usuario;
using Persistence.Repositories;

namespace ApplicationCore.RegistrarUsuario
{
    public class ControlRegistrarUsuario
    {
        IRepositorioRegistrarUsuario repo = new RepositorioRegistrarUsuario();

        public void RegistrarUsuario(string cedula, string nombre,string apellido, string correo, string celular, string contraseña)
        {
            int id = repo.GetMaxId() + 1;
            try
            {
                Usuario usuario = new Usuario(id, cedula, nombre, apellido, correo, celular, contraseña);
                repo.registrarUsusario(usuario);
            }
            catch(UsuarioYaExisteException ex)
            {
                throw ex;
            }
        }
    }
}
