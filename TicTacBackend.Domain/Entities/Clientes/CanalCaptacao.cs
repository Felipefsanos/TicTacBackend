using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Base;

namespace TicTacBackend.Domain.Entities.Clientes
{
    public class CanalCaptacao : EntidadeBase
    {
        public string Canal { get; set; }
        public List<Cliente> Cliente { get; set; }

        public CanalCaptacao()
        {

        }
    }
}
