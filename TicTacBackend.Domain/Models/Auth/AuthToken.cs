using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Models.Auth
{
    public class AuthToken
    {
        public DateTime DataExpiracao { get; set; }
        public string Token { get; set; }
    }
}
