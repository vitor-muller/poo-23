using poo_final.Data;
using poo_final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poo_final.UI
{
    public class AdicionarPratoUI
    {
        public static void Add()
        {
            using (var contexto = new RestauranteContext())
            {
                Prato novoPrato = new Prato();
                Console.Clear();
                Console.WriteLine("Adicionar Novo Prato:");

                Console.Write("Nome do Prato: ");
                novoPrato.Nome = Console.ReadLine();

                Console.Write("Descrição do Prato: ");
                novoPrato.Descrição = Console.ReadLine();

                Console.Write("Categoria do Prato: ");
                novoPrato.Categoria = Console.ReadLine();

                Console.Write("Ingredientes do Prato: ");
                novoPrato.Ingredientes = Console.ReadLine();

                Console.Write("Preço do Prato: ");
                novoPrato.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Tempo de Preparo do Prato (em minutos): ");
                novoPrato.TempoPreparo = int.Parse(Console.ReadLine());

                // Adicionar o novo prato ao contexto e salvar as alterações no banco de dados
                contexto.Pratos.Add(novoPrato);
                contexto.SaveChanges();

                Console.WriteLine("Prato adicionado ao banco de dados com sucesso!");
                Console.ReadLine();
            }
        }
    }
}
