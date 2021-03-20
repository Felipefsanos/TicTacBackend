using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Servicos.Atualiza;
using TicTacBackend.Domain.Commands.Servicos.Novo;

namespace TicTacBackend.Domain.Services.Interfaces.Servicos
{
    public interface IServicoService
    {
        void CriarServico(NovoServicoCommand novoServicoCommand);
        void AtualizarServico(AtualizaServicoCommand atualizaServicoCommand);
    }
}
