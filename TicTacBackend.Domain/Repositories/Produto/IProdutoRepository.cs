using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Repositories.Base;

namespace TicTacBackend.Domain.Repositories.Produto
{
    public interface IProdutoRepository : IRepository<Entities.Produtos.Produto>
    {
    }
}
