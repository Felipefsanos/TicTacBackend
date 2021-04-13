using System;
using System.Collections.Generic;
using TicTacBackend.Domain.Commands.Orcamentos;
using TicTacBackend.Domain.Commands.Orcamentos.Atualiza;
using TicTacBackend.Domain.Commands.Orcamentos.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Entities.Produtos;
using TicTacBackend.Domain.Entities.Servicos;
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
        public decimal ValorFrete { get; set; }
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<Produto> Produto { get; set; }
        public List<Servico> Servico { get; set; }

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
            ValidarParametrosObrigatorios(novoOrcamentoCommand);

            ValidacaoLogica.IsTrue<ValidacaoException>(novoOrcamentoCommand.Endereco is null, "Local do evento é obrigatório.");

            AtribuirValores(novoOrcamentoCommand);

            Produto = new List<Produto>();
            foreach (var item in novoOrcamentoCommand.Produtos)
            {
                Produto.Add( new Produto(item,null));
            }

            Servico = new List<Servico>();
            foreach (var item in novoOrcamentoCommand.Servicos)
            {
                Servico.Add(new Servico(item));
            }

            Local = new Local(novoOrcamentoCommand.Endereco);
        }

        public void Alterar(AlteraOrcamentoCommand alterarOrcamentoCommand)
        {
            ValidarParametrosObrigatorios(alterarOrcamentoCommand);

            ValidacaoLogica.IsTrue<ValidacaoException>(alterarOrcamentoCommand.Local is null, "Local do evento é obrigatório.");

            AtribuirValores(alterarOrcamentoCommand);

          

            Local.Alterar(alterarOrcamentoCommand.Local);
        }

        private void AtribuirValores(OrcamentoCommand orcamento)
        {
            DataEvento = orcamento.DataEvento;
            TipoEvento = orcamento.TipoEvento;
            QuantidadeAdultos = orcamento.QuantidadeAdultos;
            QuantidadeCriancas = orcamento.QuantidadeCriancas;
            BuffetPrincipal = orcamento.BuffetPrincipal;
            Observacao = orcamento.Observacao;
            Valor = orcamento.Valor;
            ValorFrete = orcamento.ValorFrete;

          
        }

        private void ValidarParametrosObrigatorios(OrcamentoCommand orcamento)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(orcamento.DataEvento == new DateTime(), "Data do evento é obrigatória.");
            ValidacaoLogica.IsTrue<ValidacaoException>(orcamento.TipoEvento == TiposEvento.Indefinido, "Tipo do evento é obrigatório.");
            ValidacaoLogica.IsTrue<ValidacaoException>(orcamento.QuantidadeAdultos < 0, "Quantidade de adultos não pode ser menor que 0");
            ValidacaoLogica.IsTrue<ValidacaoException>(orcamento.QuantidadeCriancas < 0, "Quantidade de crianças não pode ser menor que 0");
        }
    }
}
