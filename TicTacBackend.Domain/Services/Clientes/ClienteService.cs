using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Repositories.Cliente;
using TicTacBackend.Domain.Services.Interfaces.Clientes;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly ICanalCaptacaoRepository canalCaptacaoRepository;
        private readonly IClienteRepository clienteRepository;

        public ClienteService(ICanalCaptacaoRepository canalCaptacaoRepository, IClienteRepository clienteRepository)
        {
            this.canalCaptacaoRepository = canalCaptacaoRepository;
            this.clienteRepository = clienteRepository;
        }

        public void CriarCliente(NovoClienteCommand novoClienteCommand)
        {
            var canalCaptacao = canalCaptacaoRepository.ObterUm(c => c.Id == novoClienteCommand.CanalCaptacaoId);
            ValidacaoLogica.IsTrue<ValidacaoException>(canalCaptacao is null, "É obrigatório informar um canal de captação existente.");

            var cliente = new Cliente(novoClienteCommand, canalCaptacao);

            clienteRepository.Adicionar(cliente);
        }
    }
}
