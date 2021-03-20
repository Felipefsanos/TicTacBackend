using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Servicos.Atualiza
{
    public class AtualizaServicoCommand : ServicoCommand
    {
        public long Id { get; set; }
    }
}
