using System.Collections.Generic;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface ISubProdutoAppService
    {
        IEnumerable<SubProdutoData> ObterTodosSubProdutos();
        SubProdutoData ObterSubProduto(long id);
        void CriarSubProduto(SubProdutoCommand produtoCommand);
        void RemoverSubProduto(long id);
        void AtualizarSubProduto(SubProdutoCommand atualizaProdutoCommand);
    }
}
