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
    internal class RealizarPagamentoClienteUI
    {
        public static void RealizarPagamento(string nomeCliente)
        {
            using (var contexto = new RestauranteContext())
            {
                int idCliente = RealizarPagamentoClienteService.PegarIdPorNome(nomeCliente);

                Pedido pedidoAtivo = contexto.Pedidos
                    .FirstOrDefault(p => p.ClienteId == idCliente && p.Status == "Ativo");

                if (pedidoAtivo == null)
                {
                    Console.WriteLine("Não há um pedido ativo para este cliente.");
                    return;
                }

                decimal totalPedido = contexto.PratoPedidos
                .Where(pp => pp.IdPedido == pedidoAtivo.Id)
                .Sum(pp => pp.Valor);

                Console.WriteLine($"Total do Pedido: {totalPedido:C}");
                Console.WriteLine("Aguardando o pagamento");
                Console.ReadLine();
                Console.Clear();

                pedidoAtivo.Status = "Pago";

                contexto.SaveChanges();

                Console.WriteLine("Pagamento realizado com sucesso. Status do pedido: Pago");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
