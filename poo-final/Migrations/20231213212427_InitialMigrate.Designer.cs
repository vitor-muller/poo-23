﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using poo_final.Data;

#nullable disable

namespace poo_final.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    [Migration("20231213212427_InitialMigrate")]
    partial class InitialMigrate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("poo_final.Models.Mesa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Mesas");
                });

            modelBuilder.Entity("poo_final.Models.MesaReserva", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HorarioFim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("HorarioInicio")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MesaReservas");
                });

            modelBuilder.Entity("poo_final.Models.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MetodoPagamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PagamentoId")
                        .HasColumnType("int");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("poo_final.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraPedido")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Mesa")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoPagamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("poo_final.Models.Prato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Descrição")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ingredientes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("TempoPreparo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Pratos");
                });

            modelBuilder.Entity("poo_final.Models.PratoPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adicionais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdPrato")
                        .HasColumnType("int");

                    b.Property<string>("Notas")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PedidoId")
                        .HasColumnType("int");

                    b.Property<int>("PratoId")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("PratoId");

                    b.ToTable("PratoPedidos");
                });

            modelBuilder.Entity("poo_final.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoUsuario")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("TipoUsuario").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("poo_final.Models.Cliente", b =>
                {
                    b.HasBaseType("poo_final.Models.Usuario");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("cliente");
                });

            modelBuilder.Entity("poo_final.Models.Funcionario", b =>
                {
                    b.HasBaseType("poo_final.Models.Usuario");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("funcionario");
                });

            modelBuilder.Entity("poo_final.Models.PratoPedido", b =>
                {
                    b.HasOne("poo_final.Models.Pedido", "Pedido")
                        .WithMany("PratoPedidos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("poo_final.Models.Prato", "Prato")
                        .WithMany("PratoPedidos")
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Prato");
                });

            modelBuilder.Entity("poo_final.Models.Pedido", b =>
                {
                    b.Navigation("PratoPedidos");
                });

            modelBuilder.Entity("poo_final.Models.Prato", b =>
                {
                    b.Navigation("PratoPedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
