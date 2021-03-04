using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacBackend.Application.AppServices.Interfaces;
using TicTacBackend.Application.Data.Usuarios;
using TicTacBackend.Domain.Commands.Usuarios.Atualiza;
using TicTacBackend.Domain.Commands.Usuarios.Novo;

namespace TicTacBackend.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            this.usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        public IEnumerable<UsuarioData> ObterUsuarios()
        {
            return usuarioAppService.ObterTodosUsuarios(); ;
        }

        [HttpGet("{id}")]
        public UsuarioData ObterUsuario(long id)
        {
            return usuarioAppService.ObterUsuario(id);
        }

        [HttpPost]
        public void CriarUsuario(NovoUsuarioCommand novoUsuarioCommand)
        {
            usuarioAppService.CriarUsuario(novoUsuarioCommand);
        }


        [HttpPut("{id}")]
        public void CriarUsuario(long id, AtualizaUsuarioCommand atualizaUsuarioCommand)
        {
            atualizaUsuarioCommand.Id = id;
            usuarioAppService.AtualizarUsuario(atualizaUsuarioCommand);
        }
    }
}
