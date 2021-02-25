﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacBackend.Domain.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}