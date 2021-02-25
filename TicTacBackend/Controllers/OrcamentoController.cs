using Microsoft.AspNetCore.Mvc;
using TicTacBackend.Application.AppServices.Interfaces;
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
    }
}
