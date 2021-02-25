using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Models.Clientes;
using static TicTacBackend.Domain.Entities.Orcamentos.Orcamento;

namespace TicTacBackend.Domain.Commands.Orcamentos.Novo
{
    public class NovoOrcamentoCommand
    {
        public DateTime DataEvento { get; set; }
        public NovoLocalCommand Local { get; set; }
        public TiposEvento TipoEvento { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public bool BuffetPrincipal { get; set; }
        public string Observacao { get; set; }
        public NovoClienteOrcamentoModel Cliente { get; set; }
    }
}
