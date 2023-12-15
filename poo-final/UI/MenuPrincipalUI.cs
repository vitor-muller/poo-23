using poo_final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.UI
{
    public class MenuPrincipalUI
    {
        public void Iniciar()
        {
            bool continuarExecucao = true;

            while (continuarExecucao)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Cadastro");
                Console.WriteLine("3. Sair");

                string opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        RealizarLogin();
                        break;

                    case "2":
                        RealizarCadastro();
                        break;

                    case "3":
                        continuarExecucao = false;
                        Console.WriteLine("Saindo do programa...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void RealizarLogin()
        {
            LoginUI loginUI = new LoginUI();
            string nome = loginUI.FazerLogin();

            if (nome.Length > 0)
            {
                Console.WriteLine("Login bem-sucedido!");
                MenuPrincipalService.NavegarParaTela(nome);
            }
            else
            {
                Console.WriteLine("Login falhou. Tente novamente.");
            }
        }

        private void RealizarCadastro()
        {
            CadastroUI cadastroUI = new CadastroUI();
            cadastroUI.CadastrarUsuario();
        }
    }
}
