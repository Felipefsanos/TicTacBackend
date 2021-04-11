using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Orcamentos;
using TicTacBackend.Domain.Commands.Orcamentos.Atualiza;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;

namespace TicTacBackend.Controllers
{
    [Route("api/orcamentos")]
    [ApiController]
    public class OrcamentoController : ControllerBase
    {
        private readonly IOrcamentoAppService orcamentoAppService;

        public OrcamentoController(IOrcamentoAppService orcamentoAppService)
        {
            this.orcamentoAppService = orcamentoAppService;
        }

        [HttpPost]
        public void NovoOrcamento(NovoOrcamentoCommand novoOrcamentoCommand)
        {
            orcamentoAppService.CriarOrcamento(novoOrcamentoCommand);
        }

        [HttpGet]
        public IEnumerable<OrcamentoData> ObterOrcamentos(DateTime? dataInicio, DateTime? dataFim)
        {
            return orcamentoAppService.ObterOrcamentos(dataInicio, dataFim);
        }

        [HttpGet("{id}")]
        public OrcamentoData ObterOrcamento(long id)
        {
            return orcamentoAppService.ObterOrcamento(id);
        }

        [HttpPut("{id}")]
        public void EditarOrcamento(long id, AlteraOrcamentoCommand alterarOrcamentoCommand)
        {
            alterarOrcamentoCommand.Id = id;

            orcamentoAppService.AlterarOrcamento(alterarOrcamentoCommand);
        }

        [HttpDelete("{id}")]
        public void RemoverCliente(long id)
        {
            orcamentoAppService.RemoverOrcamento(id);
        }
    }
}
