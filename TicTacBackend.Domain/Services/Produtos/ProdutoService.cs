using TicTacBackend.Domain.Entities.Produtos;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Produto;
using TicTacBackend.Domain.Services.Interfaces.Produtos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISubProdutoRepository subProdutoRepository;

        public ProdutoService(
            IProdutoRepository produtoRepository,
            IUnitOfWork unitOfWork,
            ISubProdutoRepository subProdutoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.unitOfWork = unitOfWork;
            this.subProdutoRepository = subProdutoRepository;
        }

        public void AtualizarProduto(Produto produto)
        {
            var produtoId = produtoRepository.ObterUm(p => p.Id == produto.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(produtoId is null, "Produtos não encontrado.");

            produto.Atualizar(produtoId);

            produtoRepository.Atualizar(produto);
        }

        public void CriarProduto(Produto produto)
        {
            Produto produtosValidos = new Entities.Produtos.Produto(produto);
            produtoRepository.Adicionar(produtosValidos);
        }
    }
}
