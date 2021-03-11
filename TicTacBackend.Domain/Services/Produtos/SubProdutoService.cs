using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Entities.Produtos;
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

        public void AtualizarProduto(SubProdutoCommand atualizaSubProdutoCommand)
        {
            var subProduto = subProdutoRepository.ObterUm(p => p.Id == atualizaSubProdutoCommand.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(subProduto is null, "SubProduto não encontrado.");

            subProduto.Atualizar(atualizaSubProdutoCommand);

            subProdutoRepository.Atualizar(subProduto);
        }

        public void CriarProduto(SubProdutoCommand novoSubProdutoCommand)
        {
            var produto = new SubProduto(novoSubProdutoCommand);
            subProdutoRepository.Adicionar(produto);
        }
    }
}
