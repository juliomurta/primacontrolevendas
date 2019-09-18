using System;
using System.Collections.Generic;

namespace Prima.ControleVendas.Domain.Contracts
{
    public interface IGenericRepository<T>
    {
        IList<T> List(Func<T, bool> lambda = null);

        T Get(int id);

        T Get(Func<T, bool> lambda);

        void Create(T entity);

        void Edit(T entity);

        void Delete(int id);
    }
}
