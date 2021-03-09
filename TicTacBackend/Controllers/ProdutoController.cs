using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Infra.Helpers.Mapper;

namespace TicTacBackend.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            this.produtoAppService = produtoAppService;
        }

        [HttpGet]
        public IEnumerable<ProdutoData> ObterProdutos()
        {
            return produtoAppService.ObterTodosProdutos(); 
        }

        [HttpGet("{id}")]
        public ProdutoData ObterProduto(long id)
        {
            return produtoAppService.ObterProduto(id);
        }

        [HttpPost]
        public void CriarProduto(ProdutoCommand CriarprodutoCommand)
        {
            produtoAppService.CriarProduto(CriarprodutoCommand); 
        }

        [HttpDelete("{id}")]
        public void RemoverProduto(long id)
        {
            produtoAppService.RemoverProduto(id);
        }

        [HttpPut("{id}")]
        public void AtualizarProduto(long id, ProdutoCommand atualizaProdutoCommand)
        {
            atualizaProdutoCommand.Id = id;
            produtoAppService.AtualizarProduto(atualizaProdutoCommand);
        }
    }
}
