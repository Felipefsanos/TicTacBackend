using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Application.Data.Clientes;

namespace TicTacBackend.Application.Data.Prestadores
{
    public class PrestadorData
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public EnderecoData Endereco { get; set; }
        public IEnumerable<ContatoData> Contatos { get; set; }
    }
}
