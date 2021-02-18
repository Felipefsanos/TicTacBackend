using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Infra.Helpers.JwtHelpers.Interfaces
{
    public interface IJwtHelper
    {
        JwtSecurityToken GerarTokenAcesso(string nomeCompleto, decimal cpf, dynamic roles);
    }
}
