using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
    public interface IBaseBLL<T> where T : class, new()
    {
        IQueryable<T> GetPageEntities<TKey>(int pageSize, int pageIndex, out int total, Func<T, bool> whereLambda, Func<T, TKey> orderbyLambda, bool isAsc);
        T Add(T entity);

        bool Delete(T entity);

        T Update(T entity);
    }
}
