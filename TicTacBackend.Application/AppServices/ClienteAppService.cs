using AutoMapper;
using System.Collections.Generic;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Clientes;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Cliente;
using TicTacBackend.Domain.Services.Interfaces.Clientes;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper mapper;
        private readonly IClienteRepository clienteRepository;
        private readonly IClienteService clienteService;
        private readonly IUnitOfWork unitOfWork;

        public ClienteAppService(IClienteRepository clienteRepository, IUnitOfWork unitOfWork, IClienteService clienteService, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.unitOfWork = unitOfWork;
            this.clienteService = clienteService;
            this.mapper = mapper;
        }

        public void AtualizarCliente(AtualizaClienteCommand atualizaClienteCommand)
        {
            clienteService.AtualizarCliente(atualizaClienteCommand);
            unitOfWork.SaveChanges();
        }

        public void CriarCliente(NovoClienteCommand novoClienteCommand)
        {
            clienteService.CriarCliente(novoClienteCommand);
            unitOfWork.SaveChanges();
        }

        public ClienteData ObterCliente(long id)
        {
            var cliente = clienteRepository.ObterUm(c => c.Id == id, "Endereco", "Contatos", "CanalCaptacao");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(cliente is null, "Cliente não encontrado.");

            return mapper.Map<Cliente, ClienteData>(cliente);
        }

        public IEnumerable<ClienteData> ObterTodosClientes()
        {
            var clientes = clienteRepository.ObterTodos("Endereco", "Contatos", "CanalCaptacao");

            return mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteData>>(clientes);
        }

        public void RemoverCliente(long id)
        {
            var cliente = clienteRepository.ObterUm(c => c.Id == id, "Endereco", "Contatos", "CanalCaptacao");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(cliente is null, "Cliente não encontrado.");

            clienteRepository.Remover(cliente);

            unitOfWork.SaveChanges();
        }
    }
}
