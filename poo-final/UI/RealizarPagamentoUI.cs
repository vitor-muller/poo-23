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
    public class RealizarPagamentoUI
    {
        public static void RealizarPagamento()
        {
            using (var contexto = new RestauranteContext())
            {
                Console.Clear();
                if (!RealizarPagamentoService.ListarMesas())
                {
                    return;
                }

                Console.Write("Número da Mesa: ");
                int numeroMesa = int.Parse(Console.ReadLine());

                Pedido pedidoAtivo = contexto.Pedidos
                    .FirstOrDefault(p => p.Mesa == numeroMesa && p.Status == "Ativo");

                if (pedidoAtivo == null)
                {
                    Console.WriteLine("Não há um pedido ativo para esta mesa.");
                    return;
                }

                decimal totalPedido = contexto.PratoPedidos
                .Where(pp => pp.IdPedido == pedidoAtivo.Id)
                .Sum(pp => pp.Valor);

                Console.WriteLine($"Total do Pedido: {totalPedido:C}");
                Console.WriteLine("Aguardando o pagamento");
                Console.ReadLine();

                pedidoAtivo.Status = "Pago";

                // Salvar as alterações no banco de dados
                contexto.SaveChanges();

                Console.WriteLine("Pagamento realizado com sucesso. Status do pedido: Pago");
                Console.ReadLine();
            }
        }
    }
}
