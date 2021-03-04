using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Usuarios;
using TicTacBackend.Domain.Commands.Usuarios.Atualiza;
using TicTacBackend.Domain.Commands.Usuarios.Novo;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Extension.Methods;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public long Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
                
        }

        public Usuario(NovoUsuarioCommand novoUsuarioCommand)
        {
            ValidarParametros(novoUsuarioCommand);

            ValidacaoLogica.IsTrue<ValidacaoException>(novoUsuarioCommand.Cpf.IsNullOrWhiteSpace(), "CPF inválido.");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoUsuarioCommand.Login.IsNullOrWhiteSpace(), "Login inválido.");
            ValidacaoLogica.IsTrue<ValidacaoException>(novoUsuarioCommand.Login.Length < 8, "Login deve ser maior que 8 caracteres.");

            AtribuirValores(novoUsuarioCommand);

            Cpf = novoUsuarioCommand.Cpf;
            Login = novoUsuarioCommand.Login;
            Senha = novoUsuarioCommand.Cpf;
        }

        public void Alterar(AtualizaUsuarioCommand atualizaUsuarioCommand)
        {
            ValidarParametros(atualizaUsuarioCommand);

            AtribuirValores(atualizaUsuarioCommand);
        }

        private void AtribuirValores(UsuarioCommand usuarioCommand)
        {
            Nome = usuarioCommand.Nome;
            Telefone = usuarioCommand.Telefone;
        }

        private void ValidarParametros(UsuarioCommand usuarioCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(usuarioCommand.Nome.IsNullOrWhiteSpace(), "Nome de usuário não pode ser vazio ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(usuarioCommand.Telefone < 0, "Número de telefone inválido.");
        }
    }
}
