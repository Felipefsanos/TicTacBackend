using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;

namespace TicTacBackend.Controllers
{
    [Route("api/sub-produto")]
    [ApiController]
    public class SubProdutoController : ControllerBase
    {
        private readonly ISubProdutoAppService subProdutoAppService;

        public SubProdutoController(ISubProdutoAppService subProdutoAppService)
        {
            this.subProdutoAppService = subProdutoAppService;
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
            subProdutoAppService.CriarSubProduto(CriarSubprodutoCommand);
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
            subProdutoAppService.AtualizarSubProduto(atualizaSubProdutoCommand);
        }
    }
}
