using TicTacBackend.Domain.Entities;
using TicTacBackend.Domain.Repositories;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
