using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Produto;
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
    public class ComponenteAppService : IComponenteAppService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IComponenteRepository componenteRepository;
        private readonly IComponenteService componenteService;


        public ComponenteAppService(IMapper mapper,
                                 IUnitOfWork unitOfWork,
                                 IComponenteRepository componenteRepository, 
                                 IComponenteService componenteService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.componenteRepository = componenteRepository;
            this.componenteService = componenteService;
        }

        public void AtualizarComponente(AtualizacomponenteCommand atualizaComponenteCommand)
        {
            componenteService.AtualizarComponente(atualizaComponenteCommand);
            unitOfWork.SaveChanges();
        }

        public void CriarComponente(NovoComponenteCommand criarcomponenteCommand)
        {
            componenteService.CriarComponente(criarcomponenteCommand);
            unitOfWork.SaveChanges();
        }

        public ComponenteData ObterComponente(long id)
        {
            var componente = componenteRepository.ObterUm(p => p.Id == id);
            return mapper.Map<Componente, ComponenteData>(componente);
        }

        public IEnumerable<ComponenteData> ObterTodosComponentes(bool? relacionados)
        {
            var componentes = componenteRepository.ObterTodos();

            if (!relacionados.HasValue)
                return mapper.Map<IEnumerable<Componente>, IEnumerable<ComponenteData>>(componentes);
            else if (relacionados.GetValueOrDefault() == true)
                return mapper.Map<IEnumerable<Componente>, IEnumerable<ComponenteData>>(componentes.Where(s => s.Produtos.Any()));
            else
                return mapper.Map<IEnumerable<Componente>, IEnumerable<ComponenteData>>(componentes.Where(s => !s.Produtos.Any()));
        }

        public void RemoverCompomente(long id)
        {
            var SubProduto = componenteRepository.ObterUm(p => p.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(SubProduto is null, "SubProduto não encontrado.");

            componenteRepository.Remover(SubProduto);

            unitOfWork.SaveChanges();
        }
    }
}
