using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Usuarios.Atualiza
{
    public class AtualizaSenhaUsuarioCommand
    {
        public string Login { get; set; }
        public string SenhaAntiga { get; set; }
        public string NovaSenha { get; set; }
    }
}
