using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Services.Interfaces.Email
{
    public interface IEmailService
    {
        void EnviarEmailNovoOrcamento(string email, string nomeCliente);
    }
}
