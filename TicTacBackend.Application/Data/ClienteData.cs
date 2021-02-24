using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Application.Data
{
    public class ClienteData
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Observacao { get; set; }
        public EnderecoData Endereco { get; set; }
        public CanalCaptacaoData CanalCaptacao { get; set; }
        public List<ContatoData> Contatos { get; set; }
    }
}
