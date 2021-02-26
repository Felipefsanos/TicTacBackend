using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicTacBackend.Domain.Entities.Orcamentos.Orcamento;

namespace TicTacBackend.Domain.Commands.Orcamentos.Atualiza
{
    public class AlteraOrcamentoCommand : OrcamentoCommand
    {
        public long Id { get; set; }
        public AlteraLocalCommand Local { get; set; }
    }
}
