using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
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
        public List<SubProduto> SubProdutos { get; set; }
        public bool Disponivel { get; set; }

        public Produto()
        {

        }

        public Produto(Produto produto)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(produto is null, "Comando de novo produto não pode ser nulo.");

            ValidarInformacoesObrigatorias(produto);

            AtribuirValores(produto);

            SubProdutos = new List<SubProduto>();

            if(produto.SubProdutos != null)
            {
                foreach (var sub in produto.SubProdutos)
                {
                    SubProdutos.Add(sub);
                }
            }
        }

        public Produto(NovoProdutoCommand novoProdutoCommand)
        {
            ValidarInformacoesObrigatorias(novoProdutoCommand);

            AtribuirValores(novoProdutoCommand);

            SubProdutos = new List<SubProduto>();

            if (novoProdutoCommand.SubProdutos != null && novoProdutoCommand.SubProdutos.Any())
            {
                foreach (var sub in novoProdutoCommand.SubProdutos)
                {
                    SubProdutos.Add(new SubProduto(sub));
                }
            }
        }

        private void ValidarInformacoesObrigatorias(ProdutoCommand produtoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(produtoCommand.Nome.IsNullOrWhiteSpace(), "Nome do produto não pode ser vazio ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(produtoCommand.Descricao.IsNullOrWhiteSpace(), "Nome do produto não pode ser vazio ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(produtoCommand.Valor <= 0, "Valor do produto não pode ser vazio ou nulo.");
        }

        private void AtribuirValores(ProdutoCommand produtoCommand)
        {
            Nome = produtoCommand.Nome;
            Valor = produtoCommand.Valor;
            Descricao = produtoCommand.Descricao;
        }

        internal void Atualizar(AtualizaProdutoCommand atualizaProdutoCommand, List<SubProduto> novosSubProdutos)
        {
            ValidarInformacoesObrigatorias(atualizaProdutoCommand);

            AtribuirValores(atualizaProdutoCommand);

            SubProdutos.Clear();

            SubProdutos.AddRange(novosSubProdutos);
        }

        private void ValidarInformacoesObrigatorias(Produto produto)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(produto.Nome.IsNullOrWhiteSpace(), "Nome do produto não pode ser vazio ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(produto.Descricao.IsNullOrWhiteSpace(), "Nome do produto não pode ser vazio ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(produto.Valor <= 0, "Valor do produto não pode ser vazio ou nulo.");
        }
        private void AtribuirValores(Produto produto)
        {
            Nome = produto.Nome;
            Valor = produto.Valor;
            Descricao = produto.Descricao;
        }
    }

}
