using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Usuarios;
using TicTacBackend.Domain.Commands.Usuarios.Atualiza;
using TicTacBackend.Domain.Commands.Usuarios.Novo;
using TicTacBackend.Domain.Entities;
using TicTacBackend.Domain.Repositories;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UsuarioAppService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void AtualizarUsuario(AtualizaUsuarioCommand atualizaUsuarioCommand)
        {
            var usuario = usuarioRepository.ObterUm(u => u.Id == atualizaUsuarioCommand.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(usuario is null, "Usuário não encontrado.");

            usuario.Alterar(atualizaUsuarioCommand);

            usuarioRepository.Atualizar(usuario);

            unitOfWork.SaveChanges();
        }

        public void CriarUsuario(NovoUsuarioCommand novoUsuarioCommand)
        {
            var usuario = usuarioRepository.ObterUm(u => u.Cpf == novoUsuarioCommand.Cpf);

            ValidacaoLogica.IsFalse<RecursoExistenteException>(usuario is null, "Já existe um usuário com este CPF.");

            usuario = usuarioRepository.ObterUm(u => u.Login == novoUsuarioCommand.Login);

            ValidacaoLogica.IsFalse<RecursoExistenteException>(usuario is null, "Já existe um usuário com este Login.");

            usuario = new Usuario(novoUsuarioCommand);

            usuarioRepository.Adicionar(usuario);

            unitOfWork.SaveChanges();
        }

        public IEnumerable<UsuarioData> ObterTodosUsuarios()
        {
            var usuarios = usuarioRepository.ObterTodos();

            return mapper.Map<IEnumerable<UsuarioData>>(usuarios);
        }

        public UsuarioData ObterUsuario(long id)
        {
            var usuario = usuarioRepository.Obter(u => u.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(usuario is null, "Usuário não encontrado.");

            return mapper.Map<UsuarioData>(usuario);
        }

        public void TrocarSenha(AtualizaSenhaUsuarioCommand atualizaSenhaUsuarioCommand)
        {
            var usuario = usuarioRepository.ObterUm(u => u.Login == atualizaSenhaUsuarioCommand.Login);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(usuario is null, "Usuário não encontrado.");

            ValidacaoLogica.IsFalse<ValidacaoException>(usuario.Senha == atualizaSenhaUsuarioCommand.SenhaAntiga, "Senha antiga incorreta.");

            usuario.TrocarSenha(atualizaSenhaUsuarioCommand);

            unitOfWork.SaveChanges();
        }
    }
}
