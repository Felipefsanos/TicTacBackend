using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;

namespace TicTacBackend.Domain.Services.Interfaces.Produtos
{
    public interface ISubProdutoService
    {
        void CriarSubProduto(NovoSubProdutoCommand criarSubprodutoCommand);
        void AtualizarSubProduto(AtualizaSubProdutoCommand atualizaSubProdutoCommand);
    }
}
