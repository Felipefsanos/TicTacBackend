using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Atualiza;

namespace TicTacBackend.Domain.Commands.Prestadores.Atualiza
{
    public class AtualizaPrestadorCommand : PrestadorCommand
    {
        public AtualizaEnderecoCommand Endereco { get; set; }
        public List<AtualizaContatoCommand> Contatos { get; set; }
    }
}
