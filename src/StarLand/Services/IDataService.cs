using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StarLand.Services
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        T GetSingle(Expression<Func<T, bool>> predicate);
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
        void Create(T entity);
        void Update(T entity);

    }
}
