using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Repositories.Cliente;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories.Clientes
{
    public class CanalCaptacaoRepository : RepositoryBase<CanalCaptacao>, ICanalCaptacaoRepository
    {
        public CanalCaptacaoRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
