using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Novo;

namespace TicTacBackend.Domain.Services.Interfaces.Clientes
{
    public interface IClienteService
    {
        void CriarCliente(NovoClienteCommand novoClienteCommand);
    }
}
