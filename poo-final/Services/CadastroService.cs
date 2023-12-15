using poo_final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Services
{
    public class CadastroService
    {
        public static bool UsuarioExiste(string nomeUsuario)
        {
            using (var contexto = new RestauranteContext())
            {
                return contexto.Usuarios.Any(u => u.Nome == nomeUsuario);
            }
        }
    }
}
