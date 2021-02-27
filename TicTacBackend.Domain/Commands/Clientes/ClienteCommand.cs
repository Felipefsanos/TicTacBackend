using System.Collections.Generic;

namespace TicTacBackend.Domain.Commands.Clientes
{
    public class ClienteCommand
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Observacao { get; set; }
        public long CanalCaptacaoId { get; set; }
    }
}
