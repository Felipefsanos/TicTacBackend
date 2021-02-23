using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacBackend.Domain.Entities;

namespace TicTacBackend.Infra.Data.DataBase
{
    public class DataBaseContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public IQueryable<TEntity> GetDbSetWithIncludes<TEntity>(params string[] includes) where TEntity : class
        {
            IQueryable<TEntity> dbSet = Set<TEntity>();

            if (includes?.Length > 0)
                foreach (var include in includes)
                    dbSet = dbSet.Include(include);

            return dbSet;
        }

    }
}
