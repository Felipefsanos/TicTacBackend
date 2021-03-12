using TicTacBackend.Domain.Entities.Produtos;
using TicTacBackend.Domain.Repositories.Produto;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories.Produtos
{
    public class ProdutoRepository : RepositoryBase<Domain.Entities.Produtos.Produto>, IProdutoRepository
    {
        public ProdutoRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
