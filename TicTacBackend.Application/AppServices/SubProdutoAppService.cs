using AutoMapper;
using System.Collections.Generic;
using System.Linq;
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
    public class SubProdutoAppService : ISubProdutoAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ISubProdutoRepository subProdutoRepository;
        private readonly ISubProdutoService subProdutoService;


        public SubProdutoAppService(IMapper mapper,
                                 IUnitOfWork unitOfWork,
                                 ISubProdutoRepository subProdutoRepository,
                                 ISubProdutoService subProdutoService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.subProdutoRepository = subProdutoRepository;
            this.subProdutoService = subProdutoService;
        }

        public void AtualizarSubProduto(AtualizaSubProdutoCommand atualizaSubProdutoCommand)
        {
            subProdutoService.AtualizarSubProduto(atualizaSubProdutoCommand);
            unitOfWork.SaveChanges();
        }

        public void CriarSubProduto(NovoSubProdutoCommand criarSubprodutoCommand)
        {
            subProdutoService.CriarSubProduto(criarSubprodutoCommand);
            unitOfWork.SaveChanges();
        }

        public SubProdutoData ObterSubProduto(long id)
        {
            var subProduto = subProdutoRepository.ObterUm(p => p.Id == id);
            return mapper.Map<SubProduto, SubProdutoData>(subProduto);
        }

        public IEnumerable<SubProdutoData> ObterTodosSubProdutos(bool? relacionados)
        {
            var SubProdutos = subProdutoRepository.ObterTodos();

            if (!relacionados.HasValue)
                return mapper.Map<IEnumerable<SubProduto>, IEnumerable<SubProdutoData>>(SubProdutos);
            else if (relacionados.GetValueOrDefault() == true)
                return mapper.Map<IEnumerable<SubProduto>, IEnumerable<SubProdutoData>>(SubProdutos.Where(s => s.Produtos.Any()));
            else
                return mapper.Map<IEnumerable<SubProduto>, IEnumerable<SubProdutoData>>(SubProdutos.Where(s => !s.Produtos.Any()));
        }

        public void RemoverSubProduto(long id)
        {
            var SubProduto = subProdutoRepository.ObterUm(p => p.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(SubProduto is null, "SubProduto não encontrado.");

            subProdutoRepository.Remover(SubProduto);

            unitOfWork.SaveChanges();
        }
    }
}
