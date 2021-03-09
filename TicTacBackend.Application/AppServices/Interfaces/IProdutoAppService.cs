using System.Collections.Generic;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface IProdutoAppService
    {
        IEnumerable<ProdutoData> ObterTodosProdutos();
        ProdutoData ObterProduto(long id);
        void CriarProduto(ProdutoCommand produtoCommand);
        void RemoverProduto(long id);
        void AtualizarProduto(ProdutoCommand atualizaProdutoCommand);
    }
}
