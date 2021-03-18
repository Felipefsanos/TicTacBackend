using System.Collections.Generic;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Produtos;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Produto;
using TicTacBackend.Domain.Services.Interfaces.Produtos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Produtos
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly ISubProdutoRepository subProdutoRepository;

        public ProdutoService(
            IProdutoRepository produtoRepository,
            ISubProdutoRepository subProdutoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.subProdutoRepository = subProdutoRepository;
        }

        public void AtualizarProduto(AtualizaProdutoCommand atualizaProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaProdutoCommand is null, "Comando de atualizar produto não pode ser nulo.");

            var produto = produtoRepository.ObterUm(p => p.Id == atualizaProdutoCommand.Id, "SubProdutos");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(produto is null, "Produtos não encontrado.");

            List<SubProduto> novosSubProdutos = new List<SubProduto>();

            foreach (var subProdutoCommand in atualizaProdutoCommand.SubProdutos)
            {
                var subProduto = subProdutoRepository.ObterUm(s => s.Id == subProdutoCommand.Id);

                ValidacaoLogica.IsTrue<ValidacaoException>(subProduto is null, $"Sub Produto não encontrado. Id {subProdutoCommand.Id}");

                novosSubProdutos.Add(subProduto);
            }

            produto.Atualizar(atualizaProdutoCommand, novosSubProdutos);

            produtoRepository.Atualizar(produto);
        }

        public void CriarProduto(NovoProdutoCommand novoProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(novoProdutoCommand is null, "Comando de criar produto não pode ser nulo.");

            var produto = new Produto(novoProdutoCommand);

            produtoRepository.Adicionar(produto);
        }
    }
}
