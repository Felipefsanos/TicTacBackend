using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.Data.Servicos;
using TicTacBackend.Domain.Commands.Servicos.Atualiza;
using TicTacBackend.Domain.Commands.Servicos.Novo;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface IServicoAppService
    {
        IEnumerable<ServicoData> ObterServicos();
        void RemoverServico(long id);
        ServicoData ObterServico(long id);
        void CriarServico(NovoServicoCommand novoServicoCommand);
        void AtualizarServico(AtualizaServicoCommand atualizaServicoCommand);
    }
}
