﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Models.Clientes;
using static TicTacBackend.Domain.Entities.Orcamentos.Orcamento;

namespace TicTacBackend.Domain.Commands.Orcamentos.Novo
{
    public class NovoOrcamentoCommand : OrcamentoCommand
    {
        public NovoClienteOrcamentoModel Cliente { get; set; }
        public NovoLocalCommand Local { get; set; }

    }
}
