using System.Collections.Generic;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface ISubProdutoAppService
    {
        IEnumerable<SubProdutoData> ObterTodosSubProdutos();
        SubProdutoData ObterSubProduto(long id);
        void CriarSubProduto(SubProduto produto);
        void RemoverSubProduto(long id);
        void AtualizarSubProduto(SubProduto atualizaProduto);
    }
}
