using System.Collections.Generic;
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
