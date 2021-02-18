using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands;
using TicTacBackend.Domain.Models.Auth;

namespace TicTacBackend.Domain.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        AuthToken GerarToken(LoginCommand loginCommand);
    }
}
