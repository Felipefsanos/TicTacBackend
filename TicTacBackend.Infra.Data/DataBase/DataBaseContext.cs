using Microsoft.EntityFrameworkCore;
using System.Linq;
using TicTacBackend.Domain.Entities;
using TicTacBackend.Domain.Entities.Clientes;
using TicTacBackend.Domain.Entities.Orcamentos;
using TicTacBackend.Domain.Entities.Prestadores;
using TicTacBackend.Domain.Entities.Produtos;

namespace TicTacBackend.Infra.Data.DataBase
{
    public class DataBaseContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Contato> Contatos { get; set; }
        public virtual DbSet<CanalCaptacao> CanaisCaptacao { get; set; }
        public virtual DbSet<Orcamento> Orcamentos { get; set; }
        public virtual DbSet<Local> Locais { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Componente> Componentes { get; set; }
        public virtual DbSet<Prestador> Prestadores { get; set; }


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
