using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Orcamentos;
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
        public IEnumerable<OrcamentoData> ObterOrcamentos()
        {
            return orcamentoAppService.ObterOrcamentos();
        }

        [HttpGet("{id}")]
        public OrcamentoData ObterOrcamento(long id)
        {
            return orcamentoAppService.ObterOrcamento(id);
        }
    }
}
