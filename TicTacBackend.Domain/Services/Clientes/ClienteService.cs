using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;
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

        public void AtualizarCliente(AtualizaClienteCommand atualizaClienteCommand)
        {
            var cliente = clienteRepository.ObterUm(c => c.Id == atualizaClienteCommand.Id, "Endereco", "CanalCaptacao", "Contatos");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(cliente is null, "Cliente não encontrado.");

            cliente.Atualizar(atualizaClienteCommand);

            clienteRepository.Atualizar(cliente);
        }

        public void CriarCliente(NovoClienteCommand novoClienteCommand)
        {
            CanalCaptacao canalCaptacao = ObterCanalCaptacao(novoClienteCommand.CanalCaptacaoId);

            var cliente = new Cliente(novoClienteCommand, canalCaptacao);

            clienteRepository.Adicionar(cliente);
        }

        private CanalCaptacao ObterCanalCaptacao(long canalCaptacaoId)
        {
            var canalCaptacao = canalCaptacaoRepository.ObterUm(c => c.Id == canalCaptacaoId);
            ValidacaoLogica.IsTrue<ValidacaoException>(canalCaptacao is null, "É obrigatório informar um canal de captação existente.");
            return canalCaptacao;
        }
    }
}
