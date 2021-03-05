using System.Collections.Generic;
using TicTacBackend.Application.Data.Usuarios;
using TicTacBackend.Domain.Commands.Usuarios.Atualiza;
using TicTacBackend.Domain.Commands.Usuarios.Novo;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface IUsuarioAppService
    {
        IEnumerable<UsuarioData> ObterTodosUsuarios();
        UsuarioData ObterUsuario(long id);
        void CriarUsuario(NovoUsuarioCommand novoUsuarioCommand);
        void AtualizarUsuario(AtualizaUsuarioCommand atualizaUsuarioCommand);

        void TrocarSenha(AtualizaSenhaUsuarioCommand atualizaSenhaUsuarioCommand);
    }
}
