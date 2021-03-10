using TicTacBackend.Domain.Commands.Clientes.Atualiza;
using TicTacBackend.Domain.Commands.Clientes.Novo;

namespace TicTacBackend.Domain.Services.Interfaces.Clientes
{
    public interface IClienteService
    {
        void CriarCliente(NovoClienteCommand novoClienteCommand);
        void AtualizarCliente(AtualizaClienteCommand atualizaClienteCommand);
    }
}
