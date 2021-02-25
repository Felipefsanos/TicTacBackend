using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Commands.Clientes.Atualiza
{
    public class AtualizaClienteCommand
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Observacao { get; set; }
        public AtualizaEnderecoCommand Endereco { get; set; }
        public IEnumerable<AtualizaContatoCommand> Contatos { get; set; }

    }
}
