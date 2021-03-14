using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Prestadores;
using TicTacBackend.Domain.Commands.Prestadores.Atualiza;
using TicTacBackend.Domain.Commands.Prestadores.Novo;

namespace TicTacBackend.Controllers
{
    [Route("api/prestadores")]
    [ApiController]
    public class PrestadorController : ControllerBase
    {
        private readonly IPrestadorAppService PrestadorAppService;

        public PrestadorController(IPrestadorAppService PrestadorAppService)
        {
            this.PrestadorAppService = PrestadorAppService;
        }

        [HttpGet]
        public IEnumerable<PrestadorData> ObterPrestadores()
        {
            return PrestadorAppService.ObterPrestadores(); ;
        }

        [HttpGet("{id}")]
        public PrestadorData ObterPrestador(long id)
        {
            return PrestadorAppService.ObterPrestador(id);
        }

        [HttpPost]
        public void CriarPrestador(NovoPrestadorCommand novoPrestadorCommand)
        {
            PrestadorAppService.CriarPrestador(novoPrestadorCommand);
        }

        [HttpDelete("{id}")]
        public void RemoverPrestador(long id)
        {
            PrestadorAppService.RemoverPrestador(id);
        }

        [HttpPut("{id}")]
        public void CriarPrestador(long id, AtualizaPrestadorCommand atualizaPrestadorCommand)
        {
            atualizaPrestadorCommand.Id = id;
            PrestadorAppService.AtualizarPrestador(atualizaPrestadorCommand);
        }
    }
}
