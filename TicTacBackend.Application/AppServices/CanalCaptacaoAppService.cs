using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Domain.Commands.CanaisCaptacao.Atualiza;
using TicTacBackend.Domain.Repositories.Base;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly ICanalCaptacaoRepository canalCaptacaoRepository;

        public CanalCaptacaoAppService(ICanalCaptacaoRepository canalCaptacaoRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.canalCaptacaoRepository = canalCaptacaoRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public void AlterarCanalCaptacao(AtualizaCanalCaptacaoCommand canalAlterado)
        {
            var canalCaptacao = canalCaptacaoRepository.ObterUm(c => c.Id == canalAlterado.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(canalCaptacao is null, "Canal de captação não encontrado.");

            var canaisCaptacao = ObterCanaisCaptacao();

            ValidacaoLogica.IsTrue<RecursoExistenteException>(canaisCaptacao.Any(c => c.Canal == canalAlterado.Canal), "Já existe um canal de captação com este nome.");

            canalCaptacao.Canal = canalAlterado.Canal;

            unitOfWork.SaveChanges();
        }

        public IEnumerable<CanalCaptacaoData> ObterCanaisCaptacao()
        {
            var canaisCaptacao = canalCaptacaoRepository.ObterTodos();

            return mapper.Map<IEnumerable<CanalCaptacaoData>>(canaisCaptacao);
        }

        public CanalCaptacaoData ObterCanalCaptacao(long id)
        {
            var canalCaptacao = canalCaptacaoRepository.ObterUm(c => c.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(canalCaptacao is null, "Canal de captação não encontrado.");

            return Infra.Helpers.Mapper.Mapper.MapTo<CanalCaptacaoData>(canalCaptacao);
        }
    }
}
