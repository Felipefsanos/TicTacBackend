using System.Collections.Generic;
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
        public List<Produto> Produto { get; set; }
        public long Quantidade { get; set; }


        public SubProduto()
        {

        }

        public SubProduto(SubProdutoCommand subproduto)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(subproduto is null, "Comando de novo Subproduto não pode ser nulo.");

            ValidarInformacoesObrigatorias(subproduto);

            AtribuirValores(subproduto);
        }

        internal void Atualizar(SubProdutoCommand atualizaSubProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaSubProdutoCommand is null, "Comando de atualizar Subproduto não pode ser nulo.");

            ValidarInformacoesObrigatorias(atualizaSubProdutoCommand);

            AtribuirValores(atualizaSubProdutoCommand);
        }

        private void ValidarInformacoesObrigatorias(SubProdutoCommand subProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(subProdutoCommand.Nome.IsNullOrWhiteSpace(), "Nome do produto não pode ser vazio ou nulo.");
        }
        private void AtribuirValores(SubProdutoCommand novoSubProdutoCommand)
        {
            Nome = novoSubProdutoCommand.Nome;
            Descricao = novoSubProdutoCommand.Descricao;
            Quantidade = novoSubProdutoCommand.Quantidade;
            
        }
    }

}
