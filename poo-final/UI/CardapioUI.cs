using poo_final.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.UI
{
    public class CardapioUI
    {
        public static void MostrarCardapioInterativo()
        {
            using (var contexto = new RestauranteContext())
            {
                bool sair = false;

                do
                {
                    Console.WriteLine("Cardápio:");
                    MostrarCardapio(contexto);

                    Console.WriteLine("Digite o número do prato para mais informações (ou 0 para sair):");
                    string inputUsuario = Console.ReadLine();
                    Console.Clear();

                    if (inputUsuario == "0")
                    {
                        sair = true;
                    }
                    else if (int.TryParse(inputUsuario, out int idPrato))
                    {
                        MostrarDetalhesPrato(contexto, idPrato);
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite um número válido.");
                    }

                } while (!sair);
            }
        }

        private static void MostrarCardapio(RestauranteContext contexto)
        {
            var pratosPorCategoria = contexto.Pratos
                .GroupBy(p => p.Categoria)
                .ToList();

            foreach (var categoriaGrupo in pratosPorCategoria)
            {
                Console.WriteLine($"Categoria: {categoriaGrupo.Key}");

                foreach (var prato in categoriaGrupo)
                {
                    Console.WriteLine($"  ID: {prato.Id}, Nome: {prato.Nome}, Preço: {prato.Preco:C}");
                }
            }
        }

        private static void MostrarDetalhesPrato(RestauranteContext contexto, int idPrato)
        {
            var prato = contexto.Pratos.FirstOrDefault(p => p.Id == idPrato);

            if (prato != null)
            {
                Console.WriteLine($"Detalhes do Prato (ID: {prato.Id}):");
                Console.WriteLine($"Nome: {prato.Nome}");
                Console.WriteLine($"Descrição: {prato.Descrição}");
                Console.WriteLine($"Categoria: {prato.Categoria}");
                Console.WriteLine($"Ingredientes: {prato.Ingredientes}");
                Console.WriteLine($"Preço: {prato.Preco:C}");
                Console.WriteLine($"Tempo de Preparo: {prato.TempoPreparo} minutos");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"Prato com ID {idPrato} não encontrado.");
            }
        }
    }
}
