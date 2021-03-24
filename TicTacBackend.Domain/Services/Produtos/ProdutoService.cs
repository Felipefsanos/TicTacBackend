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
                var componente = componenteRepository.ObterUm(s => s.Id == subProdutoCommand.Id);

                ValidacaoLogica.IsTrue<ValidacaoException>(componente is null, $"Componete não encontrado. Id {componente.Id}");

                novosComponetes.Add(componente);
            }

            produto.Atualizar(atualizaProdutoCommand, novosComponetes);

            produtoRepository.Atualizar(produto);
        }

        public void CriarProduto(NovoProdutoCommand novoProdutoCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(novoProdutoCommand is null, "Comando de criar produto não pode ser nulo.");

            List<Componente> novosComponetes = new List<Componente>();

            foreach (var ComponenteId in novoProdutoCommand.Componentes)
            {
                var componente = componenteRepository.ObterUm(s => s.Id == ComponenteId);

                ValidacaoLogica.IsTrue<ValidacaoException>(componente is null, $"Componente não encontrado. Id {componente.Id}");

                novosComponetes.Add(componente);
            }
            var produto = new Produto(novoProdutoCommand, novosComponetes);

            produtoRepository.Adicionar(produto);
        }
    }
}
