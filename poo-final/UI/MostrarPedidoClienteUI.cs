using Microsoft.EntityFrameworkCore;
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
    internal class MostrarPedidoClienteUI
    {
        public static void MostrarPedidoAtual(string nomeCliente)
        {
            using (var contexto = new RestauranteContext())
            {
                int idCliente = MostrarPedidoClienteService.PegarIdPorNome(nomeCliente);

                Pedido pedidoCliente = contexto.Pedidos
                    .FirstOrDefault(p => p.ClienteId == idCliente && p.Status == "Ativo");

                if (pedidoCliente != null)
                {
                    Console.WriteLine($"Pedido Atual:");
                    List<int> ListaPratoPedidoID = new List<int>();
                    foreach (var pratoPedidoId in contexto.PratoPedidos
                        .Where(pp => pp.IdPedido == pedidoCliente.Id)
                        .Select(pp => pp.Id))
                    {
                        ListaPratoPedidoID.Add(pratoPedidoId);
                    }

                    if (ListaPratoPedidoID.Any())
                    {
                        decimal valorTotal = 0;
                        foreach (int id in ListaPratoPedidoID)
                        {
                            var detalhesPrato = contexto.PratoPedidos
                                .Where(pp => pp.Id == id)
                                .FirstOrDefault();

                            Prato prato = contexto.Pratos
                                .Where(pp => pp.Id == detalhesPrato.IdPrato)
                                .FirstOrDefault();

                            if (detalhesPrato != null)
                            {
                                valorTotal += detalhesPrato.Valor;
                                Console.WriteLine($"- Prato: {prato.Nome}, Quantidade: {detalhesPrato.Quantidade}, Valor: {detalhesPrato.Valor:C}");
                            }
                        }
                        Console.WriteLine($"Valor total do pedido: {valorTotal:C}");
                    }
                    else
                    {
                        Console.WriteLine($"Nenhum item foi adicionado ao pedido");
                    }
                    
                }
                else
                {
                    Console.WriteLine($"Não há um pedido ativo");
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
