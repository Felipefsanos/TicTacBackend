using AutoMapper;
using System;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Domain.Repositories.Cliente;
using TicTacBackend.Infra.Data.Repositories.Clientes;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Mapper;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Application.AppServices
{
    public class CanalCaptacaoAppService : ICanalCaptacaoAppService
    {
        private readonly IMapper mapper;
        private ICanalCaptacaoRepository canalCaptacaoRepository;

        public CanalCaptacaoAppService(ICanalCaptacaoRepository canalCaptacaoRepository, IMapper mapper)
        {
            this.canalCaptacaoRepository = canalCaptacaoRepository;
            this.mapper = mapper;
        }

        public void CriarCanalCaptacao()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CanalCaptacaoData> ObterCanaisCaptacao()
        {
            var canaisCaptacao = canalCaptacaoRepository.ObterTodos();

            //return Mapper.MapTo<IEnumerable<CanalCaptacaoData>>(canaisCaptacao);

            return mapper.Map<IEnumerable<CanalCaptacaoData>>(canaisCaptacao);
        }

        public CanalCaptacaoData ObterCanalCaptacao(long id)
        {
            var canalCaptacao = canalCaptacaoRepository.ObterUm(c => c.Id == id);

            ValidacaoLogica.IsTrue<RecursoExistenteException>(canalCaptacao is null, "Canal de captação não encontrado.");

            return Infra.Helpers.Mapper.Mapper.MapTo<CanalCaptacaoData>(canalCaptacao);
        }

        public void RemoverCanalCaptacao()
        {
            throw new NotImplementedException();
        }
    }
}
