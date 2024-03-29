﻿using AutoMapper;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Orcamentos;
using TicTacBackend.Domain.Commands.Orcamentos.Atualiza;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;
using TicTacBackend.Domain.Entities.Orcamentos;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Orcamentos;
using TicTacBackend.Domain.Services.Interfaces.Orcamentos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Application.AppServices
{
    public class OrcamentoAppService : IOrcamentoAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrcamentoService orcamentoService;
        private readonly IOrcamentoRepository orcamentoRepository;

        public OrcamentoAppService(IUnitOfWork unitOfWork, IOrcamentoService orcamentoService, IOrcamentoRepository orcamentoRepository, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.orcamentoService = orcamentoService;
            this.orcamentoRepository = orcamentoRepository;
            this.mapper = mapper;
        }

        public void AlterarOrcamento(AlteraOrcamentoCommand alterarOrcamentoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(alterarOrcamentoCommand is null, "Comando de alterar orçamento não pode ser nulo.");

            orcamentoService.AlterarOrcamento(alterarOrcamentoCommand);

            unitOfWork.SaveChanges();
        }

        public void CriarOrcamento(NovoOrcamentoCommand novoOrcamentoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(novoOrcamentoCommand is null, "Comando de criar orçamento não pode ser nulo.");

            orcamentoService.CriarOrcamento(novoOrcamentoCommand);

            unitOfWork.SaveChanges();
        }

        public OrcamentoData ObterOrcamento(long id)
        {
            var orcamento = orcamentoRepository.ObterUm(c => c.Id == id, "Local");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(orcamento is null, "Orçamento não encontrado.");

            return mapper.Map<Orcamento, OrcamentoData>(orcamento);
        }

        public IEnumerable<OrcamentoData> ObterOrcamentos()
        {
            var orcamentos = orcamentoRepository.ObterTodos("Local");

            return mapper.Map<IEnumerable<Orcamento>, IEnumerable<OrcamentoData>>(orcamentos);
        }

        public void RemoverOrcamento(long id)
        {
            var orcamento = orcamentoRepository.ObterUm(o => o.Id == id, "Local", "Cliente");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(orcamento is null, "Orçamento não encontrado.");

            orcamentoRepository.Remover(orcamento);

            unitOfWork.SaveChanges();
        }
    }
}
