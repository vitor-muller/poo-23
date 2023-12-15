using poo_final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Services
{
    public class LoginService
    {
        public static bool UsuarioExiste(string nomeUsuario)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Usuarios.Any(u => u.Nome == nomeUsuario);
            }
        }

        public static bool ValidarCredenciais(string nomeUsuario, string senha)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Usuarios.Any(u => u.Nome == nomeUsuario && u.Senha == senha);
            }
        }
    }
}
