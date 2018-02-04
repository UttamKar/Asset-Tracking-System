using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using ATS.Models.Interfaces.Repository;

namespace ATS.Repository.Common
{
    public class CommonRepository<T>:ICommonRepository<T> where T:class
    {
        protected DbContext db;

        public CommonRepository(DbContext db)
        {
            this.db = db;
        }
        public DbSet<T> Table
        {
            get { return db.Set<T>(); }
        }


        public ICollection<T> GetAll()
        {
            return Table.ToList();
        }
        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public bool Add(T entity)
        {
            Table.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(T entity)
        {
            Table.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Remove(T entity)
        {
            Table.Attach(entity);
            Table.Remove(entity);
            return db.SaveChanges() > 0;
        }

        public ICollection<T> Get(Expression<Func<T, bool>> query)
        {
            var bName = Table.Where(query);
            return bName.ToList();
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
