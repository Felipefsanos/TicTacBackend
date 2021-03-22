﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacBackend.Infra.Data.DataBase;

namespace TicTacBackend.Infra.Data.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComponenteProduto", b =>
                {
                    b.Property<long>("ComponentesId")
                        .HasColumnType("bigint");

                    b.Property<long>("ProdutosId")
                        .HasColumnType("bigint");

                    b.HasKey("ComponentesId", "ProdutosId");

                    b.HasIndex("ProdutosId");

                    b.ToTable("ComponenteProduto");
                });

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

                    b.Property<long?>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<int>("DDD")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeContato")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PrestadorId")
                        .HasColumnType("bigint");

                    b.Property<long>("Telefone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PrestadorId");

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

                    b.Property<long?>("ClienteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PrestadorId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId")
                        .IsUnique()
                        .HasFilter("[ClienteId] IS NOT NULL");

                    b.HasIndex("PrestadorId")
                        .IsUnique()
                        .HasFilter("[PrestadorId] IS NOT NULL");

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

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Orcamentos");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Prestadores.Prestador", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prestadores");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Produtos.Componente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Quantidade")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Componentes");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Produtos.Produto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Servicos.Servico", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeServico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoAlimentacao")
                        .HasColumnType("int");

                    b.Property<int>("TipoCarrinho")
                        .HasColumnType("int");

                    b.Property<int>("TipoServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Servicos");
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

                    b.Property<bool>("PrimeiroAcesso")
                        .HasColumnType("bit");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Telefone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ComponenteProduto", b =>
                {
                    b.HasOne("TicTacBackend.Domain.Entities.Produtos.Componente", null)
                        .WithMany()
                        .HasForeignKey("ComponentesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TicTacBackend.Domain.Entities.Produtos.Produto", null)
                        .WithMany()
                        .HasForeignKey("ProdutosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("ClienteId");

                    b.HasOne("TicTacBackend.Domain.Entities.Prestadores.Prestador", "Prestador")
                        .WithMany("Contatos")
                        .HasForeignKey("PrestadorId");

                    b.Navigation("Cliente");

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Clientes.Endereco", b =>
                {
                    b.HasOne("TicTacBackend.Domain.Entities.Clientes.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("TicTacBackend.Domain.Entities.Clientes.Endereco", "ClienteId");

                    b.HasOne("TicTacBackend.Domain.Entities.Prestadores.Prestador", "Prestador")
                        .WithOne("Endereco")
                        .HasForeignKey("TicTacBackend.Domain.Entities.Clientes.Endereco", "PrestadorId");

                    b.Navigation("Cliente");

                    b.Navigation("Prestador");
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

            modelBuilder.Entity("TicTacBackend.Domain.Entities.Prestadores.Prestador", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
