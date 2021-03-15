using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes;
using TicTacBackend.Domain.Commands.Clientes.Novo;

namespace TicTacBackend.Domain.Commands.Prestadores.Novo
{
    public class NovoPrestadorCommand : PrestadorCommand
    {
        public string Cpf { get; set; }
        public NovoEnderecoCommand Endereco { get; set; }
        public List<NovoContatoCommand> Contatos { get; set; }
    }
}
