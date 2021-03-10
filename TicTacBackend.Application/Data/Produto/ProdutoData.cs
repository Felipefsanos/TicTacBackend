using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Application.Data.Produto
{
    public class ProdutoData
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public List<SubProduto> SubProdutos { get; set; }
    }
}
