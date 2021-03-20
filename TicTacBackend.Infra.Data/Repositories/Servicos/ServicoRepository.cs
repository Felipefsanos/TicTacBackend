using TicTacBackend.Domain.Entities.Servicos;
using TicTacBackend.Domain.Repositories.Servicos;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories.Servicos
{
    public class ServicoRepository : RepositoryBase<Servico>, IServicoRepository
    {
        public ServicoRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
