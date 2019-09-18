using Prima.ControleVendas.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prima.ControleVendas.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        protected ApplicationDbContext context = null;

        public GenericRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        public virtual void Create(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = this.Get(id);

            if (entity == null)
            {
                return;
            }

            this.context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            this.context.Set<T>().Add(entity);
            this.context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            return this.context.Set<T>().Find(id);
        }

        public virtual T Get(Func<T, bool> lambda)
        {
            return this.context.Set<T>().FirstOrDefault(lambda);
        }

        public virtual IList<T> List(Func<T, bool> lambda = null)
        {
            if (lambda == null)
            {
                return this.context.Set<T>().ToList();
            }
            else
            {
                return this.context.Set<T>().Where(lambda).ToList();
            }
        }
    }
}
