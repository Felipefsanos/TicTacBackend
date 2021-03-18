﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Commands.Produto;
using TicTacBackend.Domain.Commands.Produto.Atualiza;
using TicTacBackend.Domain.Commands.Produto.Novo;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Domain.Services.Interfaces.Produtos
{
    public interface IProdutoService
    {
        void AtualizarProduto(AtualizaProdutoCommand atualizaProdutoCommand);
        void CriarProduto(NovoProdutoCommand novoProdutoCommand);
    }
}
