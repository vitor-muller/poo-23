using Microsoft.Extensions.Options;
using poo_final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.UI
{
    public class LoginUI
    {
        public string FazerLogin()
        {
            Console.WriteLine("Bem-vindo! Por favor, faça login:");

            Console.Write("Usuário: ");
            string usuario = Console.ReadLine();

            if (!LoginService.UsuarioExiste(usuario))
            {
                Console.WriteLine("Esse usuário não existe");
                return "";
            }

            Console.Write("Senha: ");
            string senha = Console.ReadLine();
            Console.Clear();

            if ( LoginService.ValidarCredenciais(usuario, senha) )
            {
                return usuario;
            }
            else
            {
                return "";
            }
        }
    }
}
