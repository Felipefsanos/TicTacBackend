using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Produto;

namespace TicTacBackend.Domain.Services.Interfaces.Produtos
{
    public interface ISubProdutoService
    {
        void CriarProduto(SubProdutoCommand novoSubProdutoCommand);
        void AtualizarProduto(SubProdutoCommand atualizaSubProdutoCommand);
    }
}
