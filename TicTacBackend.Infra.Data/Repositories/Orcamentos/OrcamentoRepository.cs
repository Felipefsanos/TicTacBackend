using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Orcamentos;
using TicTacBackend.Domain.Repositories.Orcamentos;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories.Orcamentos
{
    public class OrcamentoRepository : RepositoryBase<Orcamento>, IOrcamentoRepository
    {
        public OrcamentoRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
