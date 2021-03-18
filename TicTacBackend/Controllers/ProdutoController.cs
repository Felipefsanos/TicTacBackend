using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService produtoAppService;
        private readonly IMapper mapper;
        public ProdutoController(IProdutoAppService produtoAppService, IMapper mapper)
        {
            this.produtoAppService = produtoAppService;
            this.mapper = mapper;
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
        public void CriarProdutoTeste(NovoProdutoCommand criarprodutoCommand)
        {
            produtoAppService.CriarProduto(criarprodutoCommand);
        }

        [HttpDelete("{id}")]
        public void RemoverProduto(long id)
        {
            produtoAppService.RemoverProduto(id);
        }

        [HttpPut("{id}")]
        public void AtualizarProduto(long id, AtualizaProdutoCommand atualizaProdutoCommand)
        {
            atualizaProdutoCommand.Id = id;
            produtoAppService.AtualizarProduto(atualizaProdutoCommand);
        }
    }
}
