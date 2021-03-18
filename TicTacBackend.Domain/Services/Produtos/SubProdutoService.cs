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
    public class SubProdutoService : ISubProdutoService
    {
        private readonly ISubProdutoRepository subProdutoRepository;

        public SubProdutoService(ISubProdutoRepository subProdutoRepository)
        {
            this.subProdutoRepository = subProdutoRepository;
        }

        public void AtualizarSubProduto(AtualizaSubProdutoCommand atualizaSubProdutoCommand)
        {
            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(atualizaSubProdutoCommand is null, "Comando para atualizar subproduto não pode ser nulo.");

            var subProduto = subProdutoRepository.ObterUm(p => p.Id == atualizaSubProdutoCommand.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(subProduto is null, "SubProduto não encontrado.");

            subProduto.Atualizar(atualizaSubProdutoCommand);

            subProdutoRepository.Atualizar(subProduto);
        }

        public void CriarSubProduto(NovoSubProdutoCommand criarSubprodutoCommand)
        {
            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(criarSubprodutoCommand is null, "Comando de criação de subproduto não pode ser nulo.");

            var subProduto = new SubProduto(criarSubprodutoCommand);

            subProdutoRepository.Adicionar(subProduto);
        }
    }
}
