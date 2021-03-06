using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Domain.Commands.CanaisCaptacao.Atualiza;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface ICanalCaptacaoAppService
    {
        IEnumerable<CanalCaptacaoData> ObterCanaisCaptacao();
        CanalCaptacaoData ObterCanalCaptacao(long id);
        void AlterarCanalCaptacao(AtualizaCanalCaptacaoCommand canalAlterado);
    }
}
