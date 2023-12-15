using poo_final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.Services
{
    public class AdicionarItemPedidoService
    {
        public static void MostrarListaDePratos()
        {
            using (var contexto = new RestauranteContext())
            {
                var pratosPorCategoria = contexto.Pratos
                .GroupBy(p => p.Categoria)
                .ToList();

                Console.WriteLine("Lista de Pratos Disponíveis por Categoria:");

                foreach (var categoriaGrupo in pratosPorCategoria)
                {
                    Console.WriteLine($"Categoria: {categoriaGrupo.Key}");

                    foreach (var prato in categoriaGrupo)
                    {
                        decimal preco = prato.Preco;
                        string precoFormatado = preco.ToString("C", System.Globalization.CultureInfo.CurrentCulture);
                        Console.WriteLine($"  ID: {prato.Id}, Nome: {prato.Nome}, Preço: {precoFormatado}");
                    }
                }
            }
        }

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
