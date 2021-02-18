using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands;
using TicTacBackend.Domain.Models.Auth;
using TicTacBackend.Domain.Services.Interfaces.Auth;

namespace TicTacBackend.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public AuthToken RealizarLogin(LoginCommand loginCommand)
        {
            return authService.GerarToken(loginCommand);
        }
    }
}
