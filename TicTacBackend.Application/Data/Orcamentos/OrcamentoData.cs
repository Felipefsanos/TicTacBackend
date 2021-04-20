using System;
using System.Collections.Generic;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Application.Data.Servicos;
using static TicTacBackend.Domain.Entities.Orcamentos.Orcamento;

namespace TicTacBackend.Application.Data.Orcamentos
{
    public class OrcamentoData
    {
        public long Id { get; set; }
        public DateTime DataEvento { get; set; }
        public LocalData Local { get; set; }
        public TiposEvento TipoEvento { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public bool BuffetPrincipal { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public decimal ValorFrete { get; set; }
        public ClienteData Cliente { get; set; }
        public List<ProdutoData> Produto { get; set; }
        public List<ServicoData> Servico { get; set; }
    }
}
