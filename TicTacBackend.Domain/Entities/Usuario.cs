using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Base;

namespace TicTacBackend.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public long Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {
                
        }
    }
}
