using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Domain.Entities.Orcamentos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Servicos
{
    public class ServicoOrcamentoDescricao : EntidadeBase
    {
        public long ServicoId { get; set; }
        public long OrcamentoId { get; set; }
        public Orcamento Orcamento { get; set; }
        public Servico Servico { get; set; }
        public decimal valor { get; set; }
        public string observacao { get; set; }
        public int quantidade { get; set; }
        public ServicoOrcamentoDescricao()
        {

        }
        public ServicoOrcamentoDescricao(ServicoOrcamentoDescricao novoServicoOrcamentoDescricao)
        {
            ValidarInformacoesObrigatorias(novoServicoOrcamentoDescricao);

            AtribuirValores(novoServicoOrcamentoDescricao);
        }

        public void Atualizar(ServicoOrcamentoDescricao atualizaServicoOrcamentoDescricao)
        {
            ValidarInformacoesObrigatorias(atualizaServicoOrcamentoDescricao);

            AtribuirValores(atualizaServicoOrcamentoDescricao);
        }

        private void AtribuirValores(ServicoOrcamentoDescricao servicoOrcamentoDescricaoCommand)
        {
            ServicoId = servicoOrcamentoDescricaoCommand.ServicoId;
            OrcamentoId = servicoOrcamentoDescricaoCommand.OrcamentoId;
            valor = servicoOrcamentoDescricaoCommand.valor;
            observacao = servicoOrcamentoDescricaoCommand.observacao;
            quantidade = servicoOrcamentoDescricaoCommand.quantidade;
        }

        private void ValidarInformacoesObrigatorias(ServicoOrcamentoDescricao servicoOrcamentoDescricao)
        {
        }
    }
}
