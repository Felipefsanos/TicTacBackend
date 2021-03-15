using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Prestadores.Atualiza;
using TicTacBackend.Domain.Commands.Prestadores.Novo;
using TicTacBackend.Domain.Entities.Prestadores;
using TicTacBackend.Domain.Repositories.Prestadores;
using TicTacBackend.Domain.Services.Interfaces.Prestadores;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Prestadores
{
    public class PrestadorService : IPrestadorService
    {
        private readonly IPrestadorRepository prestadorRepository;

        public PrestadorService(IPrestadorRepository prestadorRepository)
        {
            this.prestadorRepository = prestadorRepository;
        }

        public void AtualizarPrestador(AtualizaPrestadorCommand atualizaPrestadorCommand)
        {
            var prestador = prestadorRepository.ObterUm(p => p.Id == atualizaPrestadorCommand.Id, "Endereco", "Contatos");

            ValidacaoLogica.IsTrue<RecursoExistenteException>(prestador is null, "Prestador não encontrado.");

            prestador.Atualizar(atualizaPrestadorCommand);

            prestadorRepository.Atualizar(prestador);
        }

        public void CriarPrestador(NovoPrestadorCommand novoPrestadorCommand)
        {
            var prestador = prestadorRepository.ObterUm(p => p.Cpf == novoPrestadorCommand.Cpf);

            ValidacaoLogica.IsFalse<RecursoExistenteException>(prestador is null, "Já existe uma prestador com este CPF.");

            prestador = new Prestador(novoPrestadorCommand);

            prestadorRepository.Adicionar(prestador);
        }
    }
}
