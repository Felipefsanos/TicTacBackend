using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;

namespace TicTacBackend.Domain.Services.Interfaces.Produtos
{
    public interface IComponenteService
    {
        void CriarComponente(NovoComponenteCommand criarSubprodutoCommand);
        void AtualizarComponente(AtualizacomponenteCommand atualizaSubProdutoCommand);
    }
}
