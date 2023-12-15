using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.UI
{
    internal class ClienteUI
    {
        public static void MostrarUI(string nomeUsuarioLogado)
        {
            bool continuarExecucao = true;

            while (continuarExecucao)
            {
                System.Console.WriteLine("Escolha uma opção:");
                System.Console.WriteLine("1. Cardápio");
                System.Console.WriteLine("2. Ver pedido");
                System.Console.WriteLine("3. Adicionar Item ao pedido");
                System.Console.WriteLine("4. Realizar o pagamento");
                System.Console.WriteLine("5. Sair");

                string opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        CardapioUI.MostrarCardapioInterativo();
                        break;

                    case "2":
                        MostrarPedidoClienteUI.MostrarPedidoAtual(nomeUsuarioLogado);
                        break;

                    case "3":
                        AdicionarItemPedidoClienteUI.Add(nomeUsuarioLogado);
                        break;

                    case "4":
                        RealizarPagamentoClienteUI.RealizarPagamento(nomeUsuarioLogado);
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
