using poo_final.Data;
using poo_final.Models;
using poo_final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.UI
{
    internal class AdicionarItemPedidoClienteUI
    {
        public static void Add(string nomeCliente)
        {
            using (var contexto = new RestauranteContext())
            {
                int idCliente = AdicionarItemPedidoClienteService.PegarIdPorNome(nomeCliente);
                Pedido pedidoAtivo = contexto.Pedidos
                    .FirstOrDefault(p => p.ClienteId == idCliente && p.Status == "Ativo");

                if (pedidoAtivo == null)
                {
                    Console.WriteLine("Não há um pedido ativo para este usuário. Crie um novo pedido antes de adicionar pratos.");
                    return;
                }

                AdicionarItemPedidoService.MostrarListaDePratos();
                Console.Write("Digite o ID do item a ser adicionado: ");
                int idPrato = int.Parse(Console.ReadLine());

                Console.WriteLine("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Algum adicional?");
                string adicionais = Console.ReadLine();

                Console.WriteLine("Alguma nota adicional?");
                string nota = Console.ReadLine();

                Prato pratoSelecionado = contexto.Pratos.FirstOrDefault(p => p.Id == idPrato);

                if (pratoSelecionado == null)
                {
                    Console.WriteLine("Prato não encontrado. Certifique-se de digitar um ID válido.");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }



                PratoPedido novoPratoPedido = new PratoPedido();
                novoPratoPedido.Prato = pratoSelecionado;
                novoPratoPedido.IdPrato = idPrato;
                novoPratoPedido.Pedido = pedidoAtivo;
                novoPratoPedido.IdPedido = pedidoAtivo.Id;
                novoPratoPedido.Quantidade = quantidade;
                novoPratoPedido.Notas = nota;
                novoPratoPedido.Adicionais = adicionais;

                novoPratoPedido.Valor = pratoSelecionado.Preco * quantidade;

                pedidoAtivo.PratoPedidos.Add(novoPratoPedido);

                contexto.SaveChanges();

                Console.WriteLine("Prato adicionado ao pedido com sucesso!");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
