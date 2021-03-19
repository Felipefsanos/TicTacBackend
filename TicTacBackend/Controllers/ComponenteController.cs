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
    [Route("api/componente")]
    [ApiController]
    public class ComponenteController : ControllerBase
    {
        private readonly IComponenteAppService componenteAppService;
        private readonly IMapper mapper;

        public ComponenteController(IComponenteAppService componenteAppService, IMapper mapper)
        {
            this.componenteAppService = componenteAppService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ComponenteData> ObterComponente(bool? relacionados = null)
        {
            return componenteAppService.ObterTodosComponentes(relacionados);
        }

        [HttpGet("{id}")]
        public ComponenteData ObterComponente(long id)
        {
            return componenteAppService.ObterComponente(id);
        }

        [HttpPost]
        public void CriarProduto(NovoComponenteCommand criarComponenteCommand)
        {
            componenteAppService.CriarComponente(criarComponenteCommand);
        }

        [HttpDelete("{id}")]
        public void RemoverProduto(long id)
        {
            componenteAppService.RemoverCompomente(id);
        }

        [HttpPut("{id}")]
        public void AtualizarProduto(long id, AtualizacomponenteCommand atualizaComponenteCommand)
        {
            atualizaComponenteCommand.Id = id;
            componenteAppService.AtualizarComponente(atualizaComponenteCommand);
        }
    }
}
