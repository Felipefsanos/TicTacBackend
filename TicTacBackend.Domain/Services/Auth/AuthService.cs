using System.IdentityModel.Tokens.Jwt;
using TicTacBackend.Domain.Commands;
using TicTacBackend.Domain.Entities;
using TicTacBackend.Domain.Models.Auth;
using TicTacBackend.Domain.Repositories;
using TicTacBackend.Domain.Services.Interfaces.Auth;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.JwtHelpers.Interfaces;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository usuariosRepository;
        private readonly IJwtHelper jwtHelper;

        public AuthService(IUsuarioRepository usuariosRepository, IJwtHelper jwtHelper)
        {
            this.usuariosRepository = usuariosRepository;
            this.jwtHelper = jwtHelper;
        }

        public AuthToken GerarToken(LoginCommand loginCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(loginCommand is null, "Comando de login não pode ser nulo.");

            loginCommand.Validar();

            var usuario = usuariosRepository.ObterUm(u => u.Login == loginCommand.Login);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(usuario is null, "Usuário não encontrado.");

            ValidacaoLogica.IsTrue<NaoAutorizadoException>(usuario.Senha != loginCommand.Password, "Senha incorrenta.");

            if(usuario.PrimeiroAcesso)
                return new AuthToken() { PrimeiroAcesso = usuario.PrimeiroAcesso };

            // TODO: Implementar as roles
            var token = jwtHelper.GerarTokenAcesso(usuario.Nome, usuario.Cpf, null);

            return new AuthToken() { DataExpiracao = token.ValidTo, Token = new JwtSecurityTokenHandler().WriteToken(token), PrimeiroAcesso = usuario.PrimeiroAcesso };
        }
    }
}
