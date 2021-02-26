using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Orcamentos.Atualiza;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;

namespace TicTacBackend.Domain.Services.Interfaces.Orcamentos
{
    public interface IOrcamentoService
    {
        void CriarOrcamento(NovoOrcamentoCommand novoOrcamentoCommand);
        void AlterarOrcamento(AlteraOrcamentoCommand alterarOrcamentoCommand);
    }
}
