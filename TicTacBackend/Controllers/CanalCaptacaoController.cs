using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Domain.Commands.CanaisCaptacao.Atualiza;

namespace TicTacBackend.Controllers
{
    [Route("api/canais-captacao")]
    [ApiController]
    public class CanalCaptacaoController : ControllerBase
    {
        private readonly ICanalCaptacaoAppService canalCaptacaoAppService;

        public CanalCaptacaoController(ICanalCaptacaoAppService canalCaptacaoAppService)
        {
            this.canalCaptacaoAppService = canalCaptacaoAppService;
        }

        [HttpGet]
        public IEnumerable<CanalCaptacaoData> ObterCanaisCaptacao()
        {
            return canalCaptacaoAppService.ObterCanaisCaptacao();
        }

        [HttpGet("{id}")]
        public CanalCaptacaoData ObterCanaisCaptacao(long id)
        {
            return canalCaptacaoAppService.ObterCanalCaptacao(id);
        }

        [HttpPut("{id}")]
        public void AlterarCanalCaptacao(long id, AtualizaCanalCaptacaoCommand canalAlterado)
        {
            canalAlterado.Id = id;
             canalCaptacaoAppService.AlterarCanalCaptacao(canalAlterado);
        }
    }
}
