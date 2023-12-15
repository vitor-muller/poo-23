using poo_final.Data;
using poo_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Services
{
    internal class MostrarPedidoClienteService
    {
        public static int PegarIdPorNome(string nome)
        {
            int id = 0;
            using (var contexto = new RestauranteContext())
            {
                Usuario usuario = contexto.Usuarios
                    .FirstOrDefault(u => u.Nome == nome);
                id = usuario.Id;
            }

            return id;
        }
    }
}
