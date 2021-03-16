using System.Collections.Generic;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface IProdutoAppService
    {
        IEnumerable<ProdutoData> ObterTodosProdutos();
        ProdutoData ObterProduto(long id);
        void CriarProduto(Produto produto);
        void RemoverProduto(long id);
        void AtualizarProduto(AtualizaProdutoCommand produto);
        void CriarProdutoTeste(NovoProdutoCommand criarprodutoCommand);
    }
}
