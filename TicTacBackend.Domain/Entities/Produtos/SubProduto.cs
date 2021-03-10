using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Produtos
{
    public class SubProduto : EntidadeBase
    {
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public long ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public SubProduto()
        {

        }

        public SubProduto(SubProduto subproduto)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(subproduto is null, "Comando de novo Subproduto não pode ser nulo.");

            ValidarInformacoesObrigatorias(subproduto);

            AtribuirValores(subproduto);
        }

        internal void Atualizar(SubProduto atualizaSubProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaSubProdutoCommand is null, "Comando de atualizar Subproduto não pode ser nulo.");

            ValidarInformacoesObrigatorias(atualizaSubProdutoCommand);

            AtribuirValores(atualizaSubProdutoCommand);
        }

        private void ValidarInformacoesObrigatorias(SubProduto subProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(subProdutoCommand.Nome.IsNullOrWhiteSpace(), "Nome do produto não pode ser vazio ou nulo.");
        }
        private void AtribuirValores(SubProduto novoSubProdutoCommand)
        {
            Nome = novoSubProdutoCommand.Nome;
            Valor = novoSubProdutoCommand.Valor;
            Descricao = novoSubProdutoCommand.Descricao;
        }
    }

}
