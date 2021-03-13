using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Prestadores;
using TicTacBackend.Domain.Repositories.Base;

namespace TicTacBackend.Domain.Repositories.Prestadores
{
    public interface IPrestadorRepository : IRepository<Prestador>
    {
    }
}
