using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Domain.Commands.Produto
{
   public class ProdutoCommand
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public List<SubProduto> SubProdutos { get; set; }
        public bool Disponivel { get; set; }
    }

}
