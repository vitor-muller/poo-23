using poo_final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Services
{
    internal class AdicionarPedidoService
    {
        public static int PegarIDPorNome(string nomeUsuario)
        {
            using (var context = new RestauranteContext())
            {
                // Consulta LINQ para obter o ID do usuário pelo nome
                int userId = context.Usuarios
                                    .Where(u => u.Nome == nomeUsuario)
                                    .Select(u => (int)u.Id)
                                    .FirstOrDefault();

                return userId;
            }
        }
    }
}
