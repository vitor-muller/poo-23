using MySql.Data.MySqlClient.Memcached;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Bcpg;
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
    internal class CadastroUI
    {
        public bool CadastrarUsuario()
        {
            RestauranteContext context = new RestauranteContext();

            Console.WriteLine("Cadastro de Novo Usuário:");

            Console.WriteLine("Nome de Usuário: ");
            string nomeUsuario = Console.ReadLine();

            if (CadastroService.UsuarioExiste(nomeUsuario))
            {
                Console.WriteLine("Esse usuário já existe");
                return false;
            }

            Console.WriteLine("Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("CPF: ");
            string cpf = Console.ReadLine();

            Console.WriteLine("Senha: ");
            string senha = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Entre o código para cadastrar funcionarios: ");
            string codigoFuncionario = Console.ReadLine();

            if (codigoFuncionario == "1234")
            {
                Console.WriteLine("Cadastrando um funcionário");
                Console.WriteLine("Entre o cargo: ");
                string cargo = Console.ReadLine();
                Console.Clear();

                Funcionario funcionario = new Funcionario
                {
                    Nome = nomeUsuario,
                    Email = email,
                    Telefone = telefone,
                    Cpf = cpf,
                    Senha = senha,
                    TipoUsuario = "funcionario",
                    Cargo = cargo

                };

                context.Usuarios.Add(funcionario);
            }
            else
            {
                Console.WriteLine("Cadastrando um Cliente");
                Console.WriteLine("Entre o endereco: ");
                string endereco = Console.ReadLine();
                Console.Clear();

                Cliente cliente = new Cliente
                {
                    Nome = nomeUsuario,
                    Email = email,
                    Telefone = telefone,
                    Cpf = cpf,
                    Senha = senha,
                    TipoUsuario = "cliente",
                    Endereco = endereco
                };

                context.Usuarios.Add(cliente);
            }

            //Salvar as mudanças no banco de dados
            context.SaveChanges();

            Console.WriteLine("Cadastrado com sucesso");

            return true;
        }
    }
}