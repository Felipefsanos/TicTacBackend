﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Produto.Atualiza
{
    public class AtualizacomponenteCommand : ComponenteCommand
    {
        public long Id { get; set; }
    }
}