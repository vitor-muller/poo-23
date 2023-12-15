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
    public class AdicionarPedidoUI
    {
        public static void Add(string NomeFuncionario)
        {
            using (var contexto = new RestauranteContext())
            {
                Pedido novoPedido = new Pedido();

                Console.WriteLine("Criando um pedido");

                //Adicionando a hora ao pedido
                novoPedido.HoraPedido = DateTime.Now;


                Console.Write("Número da Mesa: ");
                int numeroMesa = int.Parse(Console.ReadLine());

                if (contexto.Pedidos.FirstOrDefault(p => p.Mesa == numeroMesa && p.Status == "Ativo") != null)
                {
                    Console.WriteLine("Essa mesa já possui um pedido ativo");
                    return;
                }
                novoPedido.Mesa = numeroMesa;

                //Adicionando a id do Cliente
                Console.Write("Nome do Cliente: ");
                string NomeCliente = Console.ReadLine();
                int idCliente = AdicionarPedidoService.PegarIDPorNome(NomeCliente);

                if (contexto.Pedidos.FirstOrDefault(p => p.ClienteId == idCliente && p.Status == "Ativo") != null)
                {
                    Console.WriteLine("Esse cliente já possui um pedido ativo");
                    return;
                }
                if (idCliente == 0)
                {
                    Console.WriteLine("Esse cliente não existe");
                    return;
                }
                novoPedido.ClienteId = idCliente;


                //Adicionando a id do funcionário
                novoPedido.FuncionarioId = AdicionarPedidoService.PegarIDPorNome(NomeFuncionario);

                //Setando mais alguns parametros
                novoPedido.TipoPagamento = "nenhum";
                novoPedido.Status = "Ativo";

                novoPedido.PratoPedidos = new List<PratoPedido>();

                //Salvando as mudanças no banco de dados
                contexto.Pedidos.Add(novoPedido);
                contexto.SaveChanges();

                Console.WriteLine("Pedido salvo com sucesso!");
                Console.ReadLine();
            }
        }
    }
}
