using System;
using System.Collections.Generic;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities.Produtos
{
    public class SubProduto : EntidadeBase
    {
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }
        public long Quantidade { get; set; }

        public SubProduto()
        {

        }

        public SubProduto(NovoSubProdutoCommand novoSubProdutoCommand)
        {
            ValidarInformacoesObrigatorias(novoSubProdutoCommand);

            AtribuirValores(novoSubProdutoCommand);
        }

        internal void Atualizar(AtualizaSubProdutoCommand atualizaSubProdutoCommand)
        {

            ValidarInformacoesObrigatorias(atualizaSubProdutoCommand);

            AtribuirValores(atualizaSubProdutoCommand);
        }

        private static void ValidarInformacoesObrigatorias(SubProdutoCommand subProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(subProdutoCommand.Nome.IsNullOrWhiteSpace(), "Nome do Subproduto não pode ser vazio ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(subProdutoCommand.Descricao.IsNullOrWhiteSpace(), "Descrição do Subproduto não pode ser vazio ou nulo.");
        }
        private void AtribuirValores(SubProdutoCommand novoSubProdutoCommand)
        {
            Nome = novoSubProdutoCommand.Nome;
            Descricao = novoSubProdutoCommand.Descricao;
        }
    }

}
