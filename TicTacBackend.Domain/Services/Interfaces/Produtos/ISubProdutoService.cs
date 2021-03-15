using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Domain.Services.Interfaces.Produtos
{
    public interface ISubProdutoService
    {
        void CriarSubProduto(SubProduto novoSubProduto);
        void AtualizarSubProduto(SubProduto atualizaSubProduto);
    }
}
