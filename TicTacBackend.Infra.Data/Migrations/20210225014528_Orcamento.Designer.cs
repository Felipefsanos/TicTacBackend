﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacBackend.Infra.Data.DataBase;

namespace TicTacBackend.Infra.Data.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20210225014528_Orcamento")]
    partial class Orcamento
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.CanalCaptacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Canal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CanaisCaptacao");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CanalCaptacaoId")
                        .HasColumnType("bigint");

                    b.Property<string>("CpfCnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CanalCaptacaoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.Contato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<int>("DDD")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeContato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Telefone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Orcamentos.Local", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Elevador")
                        .HasColumnType("bit");

                    b.Property<bool>("Escada")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("OrcamentoId")
                        .HasColumnType("bigint");

                    b.Property<bool>("RestricaoHorario")
                        .HasColumnType("bit");

                    b.Property<int>("TamanhoLocal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrcamentoId")
                        .IsUnique();

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Orcamentos.Orcamento", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BuffetPrincipal")
                        .HasColumnType("bit");

                    b.Property<long>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DataEvento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantidadeAdultos")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeCriancas")
                        .HasColumnType("int");

                    b.Property<int>("TipoEvento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Telefone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.Cliente", b =>
                {
                    b.HasOne("TicTacBackend.Domain.Entities.Clientes.CanalCaptacao", "CanalCaptacao")
                        .WithMany("Cliente")
                        .HasForeignKey("CanalCaptacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CanalCaptacao");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.Contato", b =>
                {
                    b.HasOne("TicTacBackend.Domain.Entities.Clientes.Cliente", "Cliente")
                        .WithMany("Contatos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.Endereco", b =>
                {
                    b.HasOne("TicTacBackend.Domain.Entities.Clientes.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("TicTacBackend.Domain.Entities.Clientes.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Orcamentos.Local", b =>
                {
                    b.HasOne("TicTacBackend.Domain.Entities.Orcamentos.Orcamento", "Orcamento")
                        .WithOne("Local")
                        .HasForeignKey("TicTacBackend.Domain.Entities.Orcamentos.Local", "OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orcamento");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Orcamentos.Orcamento", b =>
                {
                    b.HasOne("TicTacBackend.Domain.Entities.Clientes.Cliente", "Cliente")
                        .WithMany("Orcamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.CanalCaptacao", b =>
                {
                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.Cliente", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Endereco");

                    b.Navigation("Orcamentos");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Orcamentos.Orcamento", b =>
                {
                    b.Navigation("Local");
                });
#pragma warning restore 612, 618
        }
    }
}
