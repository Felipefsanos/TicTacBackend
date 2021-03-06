using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.CanaisCaptacao.Atualiza
{
    public class AtualizaCanalCaptacaoCommand
    {
        public long Id { get; set; }
        public string Canal { get; set; }
    }
}
