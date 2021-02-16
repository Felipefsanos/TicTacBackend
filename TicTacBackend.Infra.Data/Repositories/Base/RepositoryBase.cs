using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TicTacBackend.Domain.Repositories.Base;
using TicTacBackend.Infra.Data.DataBase;

namespace TicTacBackend.Infra.Data.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly DataBaseContext context;
        public RepositoryBase(DataBaseContext context)
        {
            this.context = context;
        }

        public void Adicionar(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Adicionar(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public void Remover(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Remover(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public void Atualizar(IEnumerable<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
        }

        public void Atualizar(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public T ObterUm(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            return context.GetDbSetWithIncludes<T>(includes).FirstOrDefault(predicate);
        }

        public IQueryable<T> Obter(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            return context.GetDbSetWithIncludes<T>(includes).Where(predicate);
        }

        public IQueryable<T> ObterTodos(params string[] includes)
        {
            return context.GetDbSetWithIncludes<T>(includes);
        }
    }
}
