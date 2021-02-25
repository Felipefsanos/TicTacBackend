using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Models.Clientes;

namespace TicTacBackend.Domain.Commands.Clientes.Novo
{
    public class NovoClienteCommand
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Observacao { get; set; }
        public NovoEnderecoCommand Endereco { get; set; }
        public long CanalCaptacaoId { get; set; }
        public IEnumerable<NovoContatoCommand> Contatos { get; set; }

        public NovoClienteCommand()
        {

        }

        public NovoClienteCommand(NovoClienteOrcamentoModel cliente)
        {
            Nome = cliente.Nome;
            CpfCnpj = cliente.CpfCnpj;
            Observacao = cliente.Observacao;
            CanalCaptacaoId = cliente.CanalCaptacaoId;
            Contatos = cliente.Contatos;
        }
    }
}
