using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacBackend.Domain.Services.Interfaces.Email;

namespace TicTacBackend.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IEmailService emailService;

        public TestController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        [HttpGet]
        public string TestarApi()
        {
            return "Ok!";
        }

        [HttpPost("email")]
        public void TestarServiçoEmail()
        {
            emailService.EnviarEmailNovoOrcamento("lipe2008.lipao@gmail.com", "Felipe Rodrigues Ferreira Santos");
        }
    }
}
