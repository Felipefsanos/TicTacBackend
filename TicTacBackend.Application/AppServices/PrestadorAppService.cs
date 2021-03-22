﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Prestadores;
using TicTacBackend.Domain.Commands.Prestadores.Atualiza;
using TicTacBackend.Domain.Commands.Prestadores.Novo;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Domain.Repositories.Prestadores;
using TicTacBackend.Domain.Services.Interfaces.Prestadores;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Application.AppServices
{
    public class PrestadorAppService : IPrestadorAppService
    {
        private readonly IPrestadorService prestadorService;
        private readonly IPrestadorRepository prestadorRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PrestadorAppService(IMapper mapper, IUnitOfWork unitOfWork, IPrestadorRepository prestadorRepository, IPrestadorService prestadorService)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.prestadorRepository = prestadorRepository;
            this.prestadorService = prestadorService;
        }

        public void AtualizarPrestador(AtualizaPrestadorCommand atualizaPrestadorCommand)
        {
            prestadorService.AtualizarPrestador(atualizaPrestadorCommand);

            unitOfWork.SaveChanges();
        }

        public void CriarPrestador(NovoPrestadorCommand novoPrestadorCommand)
        {
            prestadorService.CriarPrestador(novoPrestadorCommand);

            unitOfWork.SaveChanges();
        }

        public PrestadorData ObterPrestador(long id)
        {
            var prestador = prestadorRepository.ObterUm(p => p.Id == id, "Endereco", "Contatos");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(prestador is null, "Prestador não encontrado.");

            return mapper.Map<PrestadorData>(prestador);
        }

        public IEnumerable<PrestadorData> ObterPrestadores()
        {
            var prestadores = prestadorRepository.ObterTodos("Endereco", "Contatos");

            return mapper.Map<IEnumerable<PrestadorData>>(prestadores);
        }

        public void RemoverPrestador(long id)
        {
            var prestador = prestadorRepository.ObterUm(p => p.Id == id, "Endereco", "Contatos");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(prestador is null, "Prestador não encontrado.");

            prestadorRepository.Remover(prestador);

            unitOfWork.SaveChanges();
        }
    }
}