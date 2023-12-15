
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.UI
{
    internal class FuncionarioUI
    {
        public static void MostrarUI(string nomeUsuarioLogado)
        {
            bool continuarExecucao = true;

            while (continuarExecucao)
            {
                System.Console.WriteLine("Escolha uma opção:");
                System.Console.WriteLine("1. Criar Pedido");
                System.Console.WriteLine("2. Adicionar Item ao pedido");
                System.Console.WriteLine("3. Realizar o pagamento");
                System.Console.WriteLine("4. Adicionar Prato");
                System.Console.WriteLine("5. Sair");

                string opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        AdicionarPedidoUI.Add(nomeUsuarioLogado);
                        break;

                    case "2":
                        AdicionarItemPedidoUI.Add();
                        break;

                    case "3":
                        RealizarPagamentoUI.RealizarPagamento();
                        break;

                    case "4":
                        AdicionarPratoUI.Add();
                        break;


                    case "5":
                        continuarExecucao = false;
                        Console.Clear();
                        Console.WriteLine("Deslogando");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
