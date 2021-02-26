using System;
using static TicTacBackend.Domain.Entities.Orcamentos.Orcamento;

namespace TicTacBackend.Domain.Commands.Orcamentos
{
    public class OrcamentoCommand
    {
        public DateTime DataEvento { get; set; }
        public TiposEvento TipoEvento { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public bool BuffetPrincipal { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
    }
}
