using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Infra.Helpers.Mapper;

namespace TicTacBackend.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            this.clienteAppService = clienteAppService;
        }

        [HttpGet]
        public IEnumerable<ClienteData> ObterClientes()
        {
            return clienteAppService.ObterTodosClientes(); ;
        }

        [HttpGet("{id}")]
        public ClienteData ObterCliente(long id)
        {
            return clienteAppService.ObterCliente(id);
        }

        [HttpPost]
        public void CriarCliente(NovoClienteCommand novoClienteCommand)
        {
            clienteAppService.CriarCliente(novoClienteCommand); 
        }

        [HttpDelete]
        public void RemoverCliente(long id)
        {
            clienteAppService.RemoverCliente(id);
        }

        [HttpPut("{id}")]
        public void CriarCliente(long id, AtualizaClienteCommand atualizaClienteCommand)
        {
            atualizaClienteCommand.Id = id;
            clienteAppService.AtualizarCliente(atualizaClienteCommand);
        }
    }
}
