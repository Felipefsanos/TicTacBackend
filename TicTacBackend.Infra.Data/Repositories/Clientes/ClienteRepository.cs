using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Repositories.Cliente;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories.Clientes
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
