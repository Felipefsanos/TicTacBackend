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
        private readonly IComponenteRepository componenteRepository;

        public ProdutoService(
            IProdutoRepository produtoRepository,
            IComponenteRepository componenteRepository)
        {
            this.produtoRepository = produtoRepository;
            this.componenteRepository = componenteRepository;
        }

        public void AtualizarProduto(componenteCommand atualizaProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(atualizaProdutoCommand is null, "Comando de atualizar produto não pode ser nulo.");

            var produto = produtoRepository.ObterUm(p => p.Id == atualizaProdutoCommand.Id, "Componentes");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(produto is null, "Produtos não encontrado.");

            List<Componente> novosComponetes = new List<Componente>();

            foreach (var subProdutoCommand in atualizaProdutoCommand.Componentes)
            {
                var subProduto = componenteRepository.ObterUm(s => s.Id == subProdutoCommand.Id);

                ValidacaoLogica.IsTrue<ValidacaoException>(subProduto is null, $"Sub Produto não encontrado. Id {subProdutoCommand.Id}");

                novosComponetes.Add(subProduto);
            }

            produto.Atualizar(atualizaProdutoCommand, novosComponetes);

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
