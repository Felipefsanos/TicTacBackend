using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Commands.Orcamentos.Atualiza;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Entities.Orcamentos;
using TicTacBackend.Domain.Repositories.Cliente;
using TicTacBackend.Domain.Repositories.Orcamentos;
using TicTacBackend.Domain.Services.Interfaces.Orcamentos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Orcamentos
{
    public class OrcamentoService : IOrcamentoService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ICanalCaptacaoRepository canalCaptacaoRepository;
        private readonly IOrcamentoRepository orcamentoRepository;

        public OrcamentoService(IClienteRepository clienteRepository, ICanalCaptacaoRepository canalCaptacaoRepository, IOrcamentoRepository orcamentoRepository)
        {
            this.clienteRepository = clienteRepository;
            this.canalCaptacaoRepository = canalCaptacaoRepository;
            this.orcamentoRepository = orcamentoRepository;
        }

        public void AlterarOrcamento(AlteraOrcamentoCommand alterarOrcamentoCommand)
        {
            var orcamento = orcamentoRepository.ObterUm(o => o.Id == alterarOrcamentoCommand.Id, "Local");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(orcamento is null, "Orçamento não encontrado.");

            orcamento.Alterar(alterarOrcamentoCommand);

            orcamentoRepository.Atualizar(orcamento);
        }

        public void CriarOrcamento(NovoOrcamentoCommand novoOrcamentoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(novoOrcamentoCommand.Cliente is null, "Deve ser informado o cliente do orçamento.");

            var cliente = clienteRepository.ObterUm(c => c.Id == novoOrcamentoCommand.Cliente.Id, "Orcamentos");

            var canalCaptacao = canalCaptacaoRepository.ObterUm(c => c.Id == novoOrcamentoCommand.Cliente.CanalCaptacaoId);

            ValidacaoLogica.IsTrue<ValidacaoException>(canalCaptacao is null, "Canal de captação do cliente não encontrado.");

            if (cliente is null)
                cliente = new Cliente(new NovoClienteCommand(novoOrcamentoCommand.Cliente), canalCaptacao);

            var orcamento = new Orcamento(novoOrcamentoCommand);

            if (cliente.Orcamentos is null)
                cliente.Orcamentos = new List<Orcamento>();

            cliente.Orcamentos.Add(orcamento);

            if (cliente.Id == 0) // Se não existir adiciona, se exisitir atualiza e inclui mais um orçamento na lista
                clienteRepository.Adicionar(cliente);
            else
                clienteRepository.Atualizar(cliente);
        }
        
    }
}
