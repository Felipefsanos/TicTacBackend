using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Servicos;
using TicTacBackend.Domain.Commands.Servicos.Atualiza;
using TicTacBackend.Domain.Commands.Servicos.Novo;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Servicos;
using TicTacBackend.Domain.Services.Interfaces.Servicos;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Application.AppServices
{
    public class ServicoAppService : IServicoAppService
    {
        private readonly IServicoService servicoService;
        private readonly IServicoRepository servicoRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ServicoAppService(IUnitOfWork unitOfWork, IMapper mapper, IServicoService servicoService, IServicoRepository servicoRepository)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.servicoService = servicoService;
            this.servicoRepository = servicoRepository;
        }

        public void AtualizarServico(AtualizaServicoCommand atualizaServicoCommand)
        {
            servicoService.AtualizarServico(atualizaServicoCommand);

            unitOfWork.SaveChanges();
        }

        public void CriarServico(NovoServicoCommand novoServicoCommand)
        {
            servicoService.CriarServico(novoServicoCommand);

            unitOfWork.SaveChanges();
        }

        public ServicoData ObterServico(long id)
        {
            var servico = servicoRepository.ObterUm(s => s.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(servico is null, "Serviço informado não encontrado.");

            return mapper.Map<ServicoData>(servico);
        }

        public IEnumerable<ServicoData> ObterServicos()
        {
            var servico = servicoRepository.ObterTodos();

            return mapper.Map<IEnumerable<ServicoData>>(servico);
        }

        public void RemoverServico(long id)
        {
            var servico = servicoRepository.ObterUm(s => s.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(servico is null, "Serviço informado não encontrado.");

            servicoRepository.Remover(servico);

            unitOfWork.SaveChanges();
        }
    }
}
