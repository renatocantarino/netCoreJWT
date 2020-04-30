using System.Collections.Generic;
using System.Linq;
using shopWeb.Models;

namespace shopWeb.Repositories
{
    public static class UsuarioRepository
    {
        public static Usuario Get(string name, string password)
        {
            var usuarios = new List<Usuario>
            {
                new Usuario {Id = 1, Name = "usuario1", Pass = "senha123", Roles = "basic"},
                new Usuario {Id = 2, Name = "usuario2", Pass = "senha1234", Roles = "admin"}
            };


            return usuarios.First(x=> x.Name.ToLower() == name.ToLower() && x.Pass == password);
        }
    }
}