using poo_final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Services
{
    public class RealizarPagamentoService
    {
        public static bool ListarMesas()
        {
            using (var contexto = new RestauranteContext())
            {
                var mesasPedidosAtivos = contexto.Pedidos
                    .Where(p => p.Status == "Ativo")
                    .Select(p => p.Mesa)
                    .Distinct()
                    .ToList();

                if (mesasPedidosAtivos.Any())
                {
                    Console.WriteLine("Mesas com Pedidos Ativos:");
                    foreach (var mesa in mesasPedidosAtivos)
                    {
                        Console.WriteLine($"Mesa: {mesa}");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("Não há pedidos ativos no momento.");
                    Console.ReadLine();
                    return false;
                }
            }
        }
    }
}
