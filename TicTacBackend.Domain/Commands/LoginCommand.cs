using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Infra.Helpers.Exceptions;
using TicTacBackend.Infra.Helpers.Extension.Methods;
using TicTacBackend.Infra.Helpers.Validation;

namespace TicTacBackend.Domain.Commands
{
    public class LoginCommand
    {
        public string Password { get; set; }
        public string Login { get; set; }

        public void Validar()
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(Login.IsNullOrEmpty(), "Usuário deve ser informado.");
            ValidacaoLogica.IsTrue<ValidacaoException>(Password.IsNullOrEmpty(), "Senha deve ser informada.");
        }
    }
}
