using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Usuarios
{
    public class UsuarioCommand
    {
        public string Nome { get; set; }
        public long Telefone { get; set; }
    }
}
