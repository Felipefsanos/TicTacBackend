using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Orcamentos;
using TicTacBackend.Domain.Repositories.Base;

namespace TicTacBackend.Domain.Repositories.Orcamentos
{
    public interface IOrcamentoRepository : IRepository<Orcamento>
    {
    }
}
