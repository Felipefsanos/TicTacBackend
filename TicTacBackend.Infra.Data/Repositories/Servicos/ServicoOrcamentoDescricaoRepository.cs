using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Servicos;
using TicTacBackend.Domain.Repositories.Servicos;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories.Servicos
{
    class ServicoOrcamentoDescricaoReposirory : RepositoryBase<ServicoOrcamentoDescricao>, IServicoOrcamentoDescricaoReposirory
    {
        public ServicoOrcamentoDescricaoReposirory(DataBaseContext context) : base(context)
        {
        }
    }
}
