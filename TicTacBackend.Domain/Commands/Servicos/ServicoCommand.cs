using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TicTacBackend.Domain.Entities.Servicos.Servico;

namespace TicTacBackend.Domain.Commands.Servicos
{
    public class ServicoCommand
    {
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public bool? Gas { get; set; }
        public TipoCarrinhos TipoCarrinho { get; set; }
        public TipoServicos TipoServico { get; set; }
    }
}
