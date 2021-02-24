using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Repositories.Base;

namespace TicTacBackend.Domain.Repositories.Cliente
{
    public interface IClienteRepository : IRepository<Entities.Clientes.Cliente>
    {
    }
}
