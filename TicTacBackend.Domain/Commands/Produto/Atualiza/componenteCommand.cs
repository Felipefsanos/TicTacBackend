using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Produto.Atualiza
{
    public class componenteCommand : ProdutoCommand
    {
        public long Id { get; set; }
        public List<AtualizacomponenteCommand> Componentes { get; set; }
    }
}
