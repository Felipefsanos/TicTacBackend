using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Produto.Novo
{
    public class NovoProdutoCommand : ProdutoCommand
    {
        public List<NovoSubProdutoCommand> SubProdutos { get; set; }
    }
}
