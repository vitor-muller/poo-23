using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using poo_final.Models;

namespace poo_final.Data
{
    internal class RestauranteContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Prato> Pratos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PratoPedido> PratoPedidos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }


        static readonly string connectionString = "Server=localhost;Database=db_restaurante;User=root;Password=password;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configurando os tipos de usuario
            modelBuilder.Entity<Usuario>()
            .HasDiscriminator<string>("TipoUsuario")
            .HasValue<Cliente>("cliente")
            .HasValue<Funcionario>("funcionario");

            //Adicionando auto-increment
            modelBuilder.Entity<PratoPedido>()
            .HasKey(e => e.Id);

            modelBuilder.Entity<PratoPedido>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
