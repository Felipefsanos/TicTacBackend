using System;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Infra.Data.DataBase;

namespace TicTacBackend.Infra.Data.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataBaseContext context;

        public UnitOfWork(DataBaseContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
