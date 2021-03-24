using System.Collections.Generic;
using System.Linq;
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
        public List<Componente> Componentes { get; set; }
        public bool Disponivel { get; set; }

        public Produto()
        {

        }

        public Produto(NovoProdutoCommand novoProdutoCommand, List<Componente> componentes)
        {
            ValidarInformacoesObrigatorias(novoProdutoCommand);

            AtribuirValores(novoProdutoCommand);

            Componentes = new List<Componente>();

            if (componentes != null && componentes.Any())
            {
                foreach (var componente in componentes)
                {
                    Componentes.Add(componente);
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

        internal void Atualizar(componenteCommand atualizaProdutoCommand, List<Componente> novoscomponente)
        {
            ValidarInformacoesObrigatorias(atualizaProdutoCommand);

            AtribuirValores(atualizaProdutoCommand);

            Componentes.Clear();

            Componentes.AddRange(novoscomponente);
        }
    }

}
