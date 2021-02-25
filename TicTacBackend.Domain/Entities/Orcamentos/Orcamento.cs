using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Orcamentos
{
    public class Orcamento : EntidadeBase
    {
        public DateTime DataEvento { get; set; }
        public Local Local  { get; set; }
        public TiposEvento TipoEvento { get; set; }
        public int QuantidadeAdultos { get; set; }
        public int QuantidadeCriancas { get; set; }
        public bool BuffetPrincipal { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public enum TiposEvento
        {
            Indefinido = 0,
            Aniversario = 1,
            Infantil = 2,
            Casamento = 3,
            Formatura = 4,
            Empresarial = 5
        }

        public Orcamento()
        {

        }

        public Orcamento(NovoOrcamentoCommand novoOrcamentoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(novoOrcamentoCommand.DataEvento == new DateTime(), "Data do evento é obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoOrcamentoCommand.Local is null, "Local do evento é obrigatório.");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoOrcamentoCommand.TipoEvento == TiposEvento.Indefinido, "Tipo do evento é obrigatório.");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoOrcamentoCommand.QuantidadeAdultos < 0, "Quantidade de adultos não pode ser menor que 0");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoOrcamentoCommand.QuantidadeCriancas < 0, "Quantidade de crianças não pode ser menor que 0");

            DataEvento = novoOrcamentoCommand.DataEvento;
            TipoEvento = novoOrcamentoCommand.TipoEvento;
            QuantidadeAdultos = novoOrcamentoCommand.QuantidadeAdultos;
            QuantidadeCriancas = novoOrcamentoCommand.QuantidadeCriancas;
            BuffetPrincipal = novoOrcamentoCommand.BuffetPrincipal;
            Observacao = novoOrcamentoCommand.Observacao;

            Local = new Local(novoOrcamentoCommand.Local);

        }
    }
}
