using System;
using System.Collections.Generic;
using System.Text;
using Domain.Usuario;
using Persistence.Repositories;

namespace ApplicationCore.RegistrarUsuario
{
    public class ControlRegistrarUsuario
    {
        RepositorioRegistrarUsuario repo = new RepositorioRegistrarUsuario();

        //public void RegistrarUsuario(string cedula, string nombre,string apellido, string correo, string celular, string contrasena)
        //{
        //    int id = repo.GetMaxId() + 1;
        //    try
        //    {
        //        Usuario usuario = new Cliente(id, nombre, apellido, "0000", "00000",correo , celular,"Calle 1", contrasena);
        //        repo.registrarUsusario(usuario);
        //    }
        //    catch(UsuarioYaExisteException ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
