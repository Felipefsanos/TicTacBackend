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
        private readonly IProdutoRepository produtoRepository;


        public SubProdutoService(ISubProdutoRepository subProdutoRepository, IUnitOfWork unitOfWork, IProdutoRepository produtoRepository)
        {
            this.subProdutoRepository = subProdutoRepository;
            this.produtoRepository = produtoRepository;
        }

        public void AtualizarSubProduto(SubProduto atualizaSubProduto)
        {
            var subProduto = subProdutoRepository.ObterUm(p => p.Id == atualizaSubProduto.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(subProduto is null, "SubProduto não encontrado.");

            subProduto.Atualizar(atualizaSubProduto);

            subProdutoRepository.Atualizar(subProduto);
        }

        public void CriarSubProduto(SubProduto novoSubProduto)
        {
            var subproduto = new SubProduto(novoSubProduto);

            subProdutoRepository.Adicionar(subproduto);
        }
    }
}
