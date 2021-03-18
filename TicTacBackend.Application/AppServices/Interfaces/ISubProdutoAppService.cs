using System.Collections.Generic;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface ISubProdutoAppService
    {
        IEnumerable<SubProdutoData> ObterTodosSubProdutos(bool? relacionados);
        SubProdutoData ObterSubProduto(long id);
        void RemoverSubProduto(long id);
        void AtualizarSubProduto(AtualizaSubProdutoCommand atualizaProduto);
        void CriarSubProduto(NovoSubProdutoCommand criarSubprodutoCommand);
    }
}
