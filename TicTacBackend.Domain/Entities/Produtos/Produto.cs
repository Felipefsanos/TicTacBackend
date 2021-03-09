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
    public class Produto : EntidadeBase
    {
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Produto()
        {

        }

        public Produto(ProdutoCommand novoProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(novoProdutoCommand is null, "Comando de novo produto não pode ser nulo.");

            ValidarInformacoesObrigatorias(novoProdutoCommand);

            AtribuirValores(novoProdutoCommand);
        }

        internal void Atualizar(ProdutoCommand atualizaProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaProdutoCommand is null, "Comando de atualizar produto não pode ser nulo.");

            ValidarInformacoesObrigatorias(atualizaProdutoCommand);

            AtribuirValores(atualizaProdutoCommand);
        }

        private void ValidarInformacoesObrigatorias(ProdutoCommand produtoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(produtoCommand.Nome.IsNullOrWhiteSpace(), "Nome do produto não pode ser vazio ou nulo.");
        }
        private void AtribuirValores(ProdutoCommand novoProdutoCommand)
        {
            Nome = novoProdutoCommand.Nome;
            Valor = novoProdutoCommand.Valor;
            Descricao = novoProdutoCommand.Descricao;
        }
    }

}
