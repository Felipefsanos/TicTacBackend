﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Application.Data.Orcamentos;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Orcamentos;
using TicTacBackend.Domain.Services.Interfaces.Orcamentos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Mapper;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Application.AppServices
{
    public class OrcamentoAppService : IOrcamentoAppService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IOrcamentoService orcamentoService;
        private readonly IOrcamentoRepository orcamentoRepository;

        public OrcamentoAppService(IUnitOfWork unitOfWork, IOrcamentoService orcamentoService, IOrcamentoRepository orcamentoRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orcamentoService = orcamentoService;
            this.orcamentoRepository = orcamentoRepository;
        }

        public void CriarOrcamento(NovoOrcamentoCommand novoOrcamentoCommand)
        {
            orcamentoService.CriarOrcamento(novoOrcamentoCommand);

            unitOfWork.SaveChanges();
        }

        public OrcamentoData ObterOrcamento(long id)
        {
            var orcamento = orcamentoRepository.ObterUm(c => c.Id == id, "Local");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(orcamento is null, "Orçamento não encontrado.");

            return Mapper.MapTo<OrcamentoData>(orcamento);
        }

        public IEnumerable<OrcamentoData> ObterOrcamentos()
        {
            var orcamentos = orcamentoRepository.ObterTodos("Local");

            return Mapper.MapTo<IEnumerable<OrcamentoData>>(orcamentos);
        }
    }
}