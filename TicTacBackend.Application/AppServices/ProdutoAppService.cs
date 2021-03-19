﻿using AutoMapper;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Produtos;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Produto;
using TicTacBackend.Domain.Services.Interfaces.Produtos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Application.AppServices
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProdutoRepository produtoRepository;
        private readonly IProdutoService produtoService;


        public ProdutoAppService(IMapper mapper,
                                 IUnitOfWork unitOfWork,
                                 IProdutoRepository produtoRepository,
                                 IProdutoService produtoService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.produtoRepository = produtoRepository;
            this.produtoService = produtoService;
        }

        public void AtualizarProduto(componenteCommand atualizaProdutoCommand)
        {
            produtoService.AtualizarProduto(atualizaProdutoCommand);
            unitOfWork.SaveChanges();
        }

        public void CriarProduto(NovoProdutoCommand novoProdutoCommand)
        {
            produtoService.CriarProduto(novoProdutoCommand);
            unitOfWork.SaveChanges();
        }

        public ProdutoData ObterProduto(long id)
        {
            var produto = produtoRepository.ObterUm(p => p.Id == id, "Componentes");
            return mapper.Map<Produto, ProdutoData>(produto);
        }

        public IEnumerable<ProdutoData> ObterTodosProdutos()
        {
            var produtos = produtoRepository.ObterTodos("Componentes");
            return mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoData>>(produtos);
        }

        public void RemoverProduto(long id)
        {
            var produto = produtoRepository.ObterUm(p => p.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(produto is null, "Produtos não encontrado.");

            produtoRepository.Remover(produto);

            unitOfWork.SaveChanges();
        }
    }
}
