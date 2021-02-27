using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Application.Data.Orcamentos;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Entities.Orcamentos;

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

        }
    }
}
