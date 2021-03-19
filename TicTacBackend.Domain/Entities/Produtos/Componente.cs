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
    public class Componente : EntidadeBase
    {
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }
        public long Quantidade { get; set; }

        public Componente()
        {

        }

        public Componente(NovoComponenteCommand novoSubProdutoCommand)
        {
            ValidarInformacoesObrigatorias(novoSubProdutoCommand);

            AtribuirValores(novoSubProdutoCommand);
        }

        internal void Atualizar(AtualizacomponenteCommand atualizaSubProdutoCommand)
        {

            ValidarInformacoesObrigatorias(atualizaSubProdutoCommand);

            AtribuirValores(atualizaSubProdutoCommand);
        }

        private static void ValidarInformacoesObrigatorias(ComponenteCommand subProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(subProdutoCommand.Nome.IsNullOrWhiteSpace(), "Nome do Subproduto não pode ser vazio ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(subProdutoCommand.Descricao.IsNullOrWhiteSpace(), "Descrição do Subproduto não pode ser vazio ou nulo.");
        }
        private void AtribuirValores(ComponenteCommand novoSubProdutoCommand)
        {
            Nome = novoSubProdutoCommand.Nome;
            Descricao = novoSubProdutoCommand.Descricao;
        }
    }

}
