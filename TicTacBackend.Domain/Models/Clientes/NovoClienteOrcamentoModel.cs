using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Clientes.Novo;
using TicTacBackend.Domain.Entities.Clientes;

namespace TicTacBackend.Domain.Models.Clientes
{
    public class NovoClienteOrcamentoModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Observacao { get; set; }
        public long CanalCaptacaoId { get; set; }
        public IEnumerable<NovoContatoCommand> Contatos { get; set; }
    }
}
