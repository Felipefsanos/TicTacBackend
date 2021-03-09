using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Base;

namespace TicTacBackend.Domain.Entities.Produtos
{
    public class Produto : EntidadeBase
    {
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
