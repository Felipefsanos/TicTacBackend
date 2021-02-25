using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.Data;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;
using TicTacBackend.Domain.Commands.Clientes.Novo;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface IClienteAppService
    {
        IEnumerable<ClienteData> ObterTodosClientes();
        ClienteData ObterCliente(long id);
        void RemoverCliente(long id);
        void CriarCliente(NovoClienteCommand novoClienteCommand);
        void AtualizarCliente(AtualizaClienteCommand atualizaClienteCommand);
    }
}
