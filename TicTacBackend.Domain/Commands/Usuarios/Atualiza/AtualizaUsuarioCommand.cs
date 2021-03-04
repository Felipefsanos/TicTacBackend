using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Usuarios.Atualiza
{
    public class AtualizaUsuarioCommand : UsuarioCommand
    {
        public long Id { get; set; }
    }
}
