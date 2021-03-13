using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Base;
using TicTacBackend.Domain.Entities.Clientes;

namespace TicTacBackend.Domain.Entities.Prestadores
{
    public class Prestador : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
        public List<Contato> Contatos { get; set; }
    }
}
