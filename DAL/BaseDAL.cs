
using EF_DAL;
using EF_Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDAL<T> where T:class,new()
    {
        //CRUD
        private DbContext db = EFDbContextFactory.GetEFSpringContext();

        public IQueryable<T> GetPageEntities<TKey>(int pageSize,int pageIndex,out int total,Func<T,bool> whereLambda,Func<T,TKey> orderbyLambda,bool isAsc)
        {
            total = db.Set<T>().Count();
            if (isAsc)
            {
                var temp = db.Set<T>().Where(whereLambda).OrderBy<T,TKey>(orderbyLambda).Skip(pageSize*(pageIndex-1)).Take(pageSize);
                return temp.AsQueryable();
            }
            else
            {
                var temp = db.Set<T>().Where(whereLambda).OrderByDescending<T, TKey>(orderbyLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                return temp.AsQueryable();
            }
        }
        public T Add(T entity)
        {
            db.Set<T>().Add(entity);
            //db.SaveChanges();
            return entity;
        }

        public bool Delete(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Deleted;
            //return db.SaveChanges()>0;
            return true;
        }

        public T Update(T entity)
        {
            db.Entry<T>(entity).State = EntityState.Modified;
            //db.SaveChanges();
            return entity;
        }


    }
}
