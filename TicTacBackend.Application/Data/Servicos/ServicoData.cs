using static TicTacBackend.Domain.Entities.Servicos.Servico;

namespace TicTacBackend.Application.Data.Servicos
{
    public class ServicoData
    {
        public long Id { get; set; }
        public string NomeServico { get; set; }
        public string Descricao { get; set; }
        public TiposAlimentacao? TipoAlimentacao { get; set; }
        public TipoCarrinhos TipoCarrinho { get; set; }
        public TipoServicos TipoServico { get; set; }
    }
}
