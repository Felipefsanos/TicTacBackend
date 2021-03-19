using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Application.Data.Orcamentos;
using TicTacBackend.Application.Data.Prestadores;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Application.Data.Usuarios;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Entities;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Entities.Orcamentos;
using TicTacBackend.Domain.Entities.Prestadores;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void MapperConfig(IMapperConfigurationExpression config)
        {
            config.CreateMap<Cliente, ClienteData>();
            config.CreateMap<ClienteData, Cliente>();

            config.CreateMap<Endereco, EnderecoData>();
            config.CreateMap<EnderecoData, Endereco>();

            config.CreateMap<Contato, ContatoData>();
            config.CreateMap<ContatoData, Contato>();

            config.CreateMap<Orcamento, OrcamentoData>();
            config.CreateMap<OrcamentoData, Orcamento>();

            config.CreateMap<Local, LocalData>();
            config.CreateMap<LocalData, Local>();

            config.CreateMap<CanalCaptacao, CanalCaptacaoData>();
            config.CreateMap<CanalCaptacaoData, CanalCaptacao>();

            config.CreateMap<Usuario, UsuarioData>();
            config.CreateMap<UsuarioData, Usuario>();

            config.CreateMap<Produto, ProdutoData>();
            config.CreateMap<ProdutoData, Produto>();

            config.CreateMap<Componente, ComponenteData>();
            config.CreateMap<ComponenteData, Componente > ();

            config.CreateMap<ProdutoCommand, Produto>();
            config.CreateMap<Produto, ProdutoCommand>();


            config.CreateMap<ComponenteCommand, Componente>();
            config.CreateMap<Componente, ComponenteCommand>();



            config.CreateMap<Prestador, PrestadorData>();
            config.CreateMap<PrestadorData, Prestador>();

        }
    }
}
