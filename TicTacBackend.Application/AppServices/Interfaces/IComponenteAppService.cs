using System.Collections.Generic;
using TicTacBackend.Application.Data.Produto;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Application.AppServices.Interfaces
{
    public interface IComponenteAppService
    {
        IEnumerable<ComponenteData> ObterTodosComponentes(bool? relacionados);
        ComponenteData ObterComponente(long id);
        void RemoverCompomente(long id);
        void AtualizarComponente(AtualizacomponenteCommand atualizaProduto);
        void CriarComponente(NovoComponenteCommand criarSubprodutoCommand);
    }
}
