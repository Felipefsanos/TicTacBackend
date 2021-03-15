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
                    sub.Produtos.Add(produto);
                    SubProdutos.Add(new SubProduto(sub));
                }
            }
           
        }

        internal void Atualizar(Produto atualizaProduto)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaProduto is null, "Comando de atualizar produto não pode ser nulo.");

            ValidarInformacoesObrigatorias(atualizaProduto);

            AtribuirValores(atualizaProduto);

            SubProdutos = new List<SubProduto>();

            if (atualizaProduto.SubProdutos != null)
            {
                foreach (var sub in atualizaProduto.SubProdutos)
                {
                    sub.Produtos.Add(atualizaProduto);
                    SubProdutos.Add(new SubProduto(sub));
                }
            }
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
