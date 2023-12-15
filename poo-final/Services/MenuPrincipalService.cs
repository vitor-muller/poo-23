using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using poo_final.Data;
using poo_final.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace poo_final.Services
{
    public class MenuPrincipalService
    {
        public static string ObterTipoUsuario(string nomeUsuario)
        {
            using (var contexto = new RestauranteContext())
            {
                var tipoUsuario = contexto.Usuarios
                            .Where(u => u.Nome == nomeUsuario)
                            .Select(u => u.TipoUsuario)
                            .FirstOrDefault();

                return tipoUsuario;
            }
        }

        public static void NavegarParaTela(string usuario)
        {
            string tipoUsuario = ObterTipoUsuario(usuario);
            switch (tipoUsuario.ToLower())
            {
                case "funcionario":
                    FuncionarioUI.MostrarUI(usuario);
                    break;

                case "cliente":
                    ClienteUI.MostrarUI(usuario);
                    break;

                default:
                    Console.WriteLine("Tipo de usuário não reconhecido. Não é possível navegar para uma tela específica.");
                    break;
            }



        }
    }
}
