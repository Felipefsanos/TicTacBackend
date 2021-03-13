using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Prestadores;
using TicTacBackend.Domain.Repositories.Prestadores;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories.Prestadores
{
    public class PrestadorRepository : RepositoryBase<Prestador>, IPrestadorRepository
    {
        public PrestadorRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
