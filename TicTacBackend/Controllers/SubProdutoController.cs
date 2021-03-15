using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Controllers
{
    [Route("api/sub-produtos")]
    [ApiController]
    public class SubProdutoController : ControllerBase
    {
        private readonly ISubProdutoAppService subProdutoAppService;
        private readonly IMapper mapper;

        public SubProdutoController(ISubProdutoAppService subProdutoAppService, IMapper mapper)
        {
            this.subProdutoAppService = subProdutoAppService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<SubProdutoData> ObterSubProdutos()
        {
            return subProdutoAppService.ObterTodosSubProdutos();
        }

        [HttpGet("{id}")]
        public SubProdutoData ObterSubProduto(long id)
        {
            return subProdutoAppService.ObterSubProduto(id);
        }

        [HttpPost]
        public void CriarProduto(SubProdutoCommand CriarSubprodutoCommand)
        {
            var CriarSubproduto = mapper.Map<SubProdutoCommand, SubProduto>(CriarSubprodutoCommand);
            subProdutoAppService.CriarSubProduto(CriarSubproduto);
        }

        [HttpDelete("{id}")]
        public void RemoverProduto(long id)
        {
            subProdutoAppService.RemoverSubProduto(id);
        }

        [HttpPut("{id}")]
        public void AtualizarProduto(long id, SubProdutoCommand atualizaSubProdutoCommand)
        {
            atualizaSubProdutoCommand.Id = id;
            var atualizaSubProduto = mapper.Map<SubProdutoCommand, SubProduto>(atualizaSubProdutoCommand);
            subProdutoAppService.AtualizarSubProduto(atualizaSubProduto);
        }
    }
}
