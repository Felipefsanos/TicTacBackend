using System;
using TicTacBackend.Domain.Commands.Servicos.Atualiza;
using TicTacBackend.Domain.Commands.Servicos.Novo;
using TicTacBackend.Domain.Entities.Servicos;
using TicTacBackend.Domain.Repositories.Servicos;
using TicTacBackend.Domain.Services.Interfaces.Servicos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Servicos
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository servicoRepository;

        public ServicoService(IServicoRepository servicoRepository)
        {
            this.servicoRepository = servicoRepository;
        }

        public void AtualizarServico(AtualizaServicoCommand atualizaServicoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaServicoCommand is null, "Comando de atualização de serviço não pode ser nulo.");

            var servico = servicoRepository.ObterUm(s => s.Id == atualizaServicoCommand.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(servico is null, "Serviço informado não encontrado.");

            servico.Atualizar(atualizaServicoCommand);

            servicoRepository.Atualizar(servico);
        }

        public void CriarServico(NovoServicoCommand novoServicoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(novoServicoCommand is null, "Comando de criação de serviço não pode ser nulo.");

            var servico = servicoRepository.ObterUm(s => s.Descricao == novoServicoCommand.NomeServico);

            ValidacaoLogica.IsFalse<ValidacaoException>(servico is null, "Já existe um serviço com essse nome.");

            servico = new Servico(novoServicoCommand);

            servicoRepository.Adicionar(servico);

        }
    }
}
