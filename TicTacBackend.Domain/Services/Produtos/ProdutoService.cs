using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Entities.Produtos;
using TicTacBackend.Domain.Repositories.Produto;
using TicTacBackend.Domain.Services.Interfaces.Produtos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public void AtualizarProduto(ProdutoCommand atualizaProdutoCommand)
        {
            var produto = produtoRepository.ObterUm(p => p.Id == atualizaProdutoCommand.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(produto is null, "Produto não encontrado.");

            produto.Atualizar(atualizaProdutoCommand);

            produtoRepository.Atualizar(produto);
        }

        public void CriarProduto(ProdutoCommand novoProdutoCommand)
        {
            var produto = new Produto(novoProdutoCommand);
            produtoRepository.Adicionar(produto);
        }
    }
}
