using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.Data.Orcamentos;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface IOrcamentoAppService
    {
        void CriarOrcamento(NovoOrcamentoCommand novoOrcamentoCommand);
        IEnumerable<OrcamentoData> ObterOrcamentos();
        OrcamentoData ObterOrcamento(long id);
    }
}
