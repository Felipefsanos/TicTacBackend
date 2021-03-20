using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Servicos;
using TicTacBackend.Domain.Commands.Servicos.Atualiza;
using TicTacBackend.Domain.Commands.Servicos.Novo;

namespace TicTacBackend.Controllers
{
    [Route("api/servicos")]
    [ApiController]
    public class ServicoController : ControllerBase
    {
        private readonly IServicoAppService servicoAppService;

        public ServicoController(IServicoAppService servicoAppService)
        {
            this.servicoAppService = servicoAppService;
        }

        [HttpGet]
        public IEnumerable<ServicoData> ObterCanaisCaptacao()
        {
            return servicoAppService.ObterServicos();
        }

        [HttpGet("{id}")]
        public ServicoData ObterServico(long id)
        {
            return servicoAppService.ObterServico(id);
        }

        [HttpPost]
        public void CriarServico(NovoServicoCommand novoServicoCommand)
        {
            servicoAppService.CriarServico(novoServicoCommand); 
        }

        [HttpDelete("{id}")]
        public void RemoverServico(long id)
        {
            servicoAppService.RemoverServico(id);
        }

        [HttpPut("{id}")]
        public void CriarServico(long id, AtualizaServicoCommand atualizaServicoCommand)
        {
            atualizaServicoCommand.Id = id;
            servicoAppService.AtualizarServico(atualizaServicoCommand);
        }
    }
}
