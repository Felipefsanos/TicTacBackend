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
        public List<Produto> Produtos { get; set; }
        public long ProdutoId { get; set; }

        public SubProduto()
        {

        }

        public SubProduto(SubProduto subproduto)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(subproduto is null, "Comando de novo Subproduto não pode ser nulo.");

            ValidarInformacoesObrigatorias(subproduto);

            AtribuirValores(subproduto);

            Produtos = new List<Produto>();

            if(subproduto.Produtos != null)
            {
                foreach (var prod in subproduto.Produtos)
                {
                    prod.SubProdutos = new List<SubProduto>();
                    prod.SubProdutos.Add(subproduto);
                    Produtos.Add(prod);
                }
            }
            
        }

        internal void Atualizar(SubProduto atualizaSubProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaSubProdutoCommand is null, "Comando de atualizar Subproduto não pode ser nulo.");

            ValidarInformacoesObrigatorias(atualizaSubProdutoCommand);

            AtribuirValores(atualizaSubProdutoCommand);

            Produtos = new List<Produto>();

            if (atualizaSubProdutoCommand.Produtos != null)
            {
                foreach (var prod in atualizaSubProdutoCommand.Produtos)
                {
                    prod.SubProdutos = new List<SubProduto>();
                    prod.SubProdutos.Add(atualizaSubProdutoCommand);
                    Produtos.Add(prod);
                }
            }
        }

        private void ValidarInformacoesObrigatorias(SubProduto subProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(subProdutoCommand.Nome.IsNullOrWhiteSpace(), "Nome do Subproduto não pode ser vazio ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(subProdutoCommand.Descricao.IsNullOrWhiteSpace(), "Descrição do Subproduto não pode ser vazio ou nulo.");
        }
        private void AtribuirValores(SubProduto novoSubProdutoCommand)
        {
            Nome = novoSubProdutoCommand.Nome;
            Descricao = novoSubProdutoCommand.Descricao;
            
        }
    }

}
