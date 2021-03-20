using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Produtos;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Produto;
using TicTacBackend.Domain.Services.Interfaces.Produtos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Produtos
{
    public class ComponenteService : IComponenteService
    {
        private readonly IComponenteRepository componenteRepository;

        public ComponenteService(IComponenteRepository componenteRepository)
        {
            this.componenteRepository = componenteRepository;
        }

        public void AtualizarComponente(AtualizacomponenteCommand atualizaComponenteCommand)
        {
            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(atualizaComponenteCommand is null, "Comando para atualizar subproduto não pode ser nulo.");

            var componente = componenteRepository.ObterUm(p => p.Id == atualizaComponenteCommand.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(componente is null, "SubProduto não encontrado.");

            componente.Atualizar(atualizaComponenteCommand);

            componenteRepository.Atualizar(componente);
        }

        public void CriarComponente(NovoComponenteCommand criarComponenteCommand)
        {
            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(criarComponenteCommand is null, "Comando de criação de subproduto não pode ser nulo.");

            var subProduto = new Componente(criarComponenteCommand);

            componenteRepository.Adicionar(subProduto);
        }
    }
}
