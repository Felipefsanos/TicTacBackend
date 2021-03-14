using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Prestadores.Atualiza;
using TicTacBackend.Domain.Commands.Prestadores.Novo;

namespace TicTacBackend.Domain.Services.Interfaces.Prestadores
{
    public interface IPrestadorService
    {
        void CriarPrestador(NovoPrestadorCommand novoPrestadorCommand);
        void AtualizarPrestador(AtualizaPrestadorCommand atualizaPrestadorCommand);
    }
}
