﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities.Produtos;
using TicTacBackend.Domain.Repositories.Produto;
using TicTacBackend.Infra.Data.DataBase;
using TicTacBackend.Infra.Data.Repositories.Base;

namespace TicTacBackend.Infra.Data.Repositories.Produtos
{
    public class SubProdutoRepository : RepositoryBase<SubProduto>, ISubProdutoRepository
    {
        public SubProdutoRepository(DataBaseContext context) : base(context)
        {
        }
    }
}
