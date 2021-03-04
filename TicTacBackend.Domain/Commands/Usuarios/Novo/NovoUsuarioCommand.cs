using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Usuarios.Novo
{
    public class NovoUsuarioCommand : UsuarioCommand
    {
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
