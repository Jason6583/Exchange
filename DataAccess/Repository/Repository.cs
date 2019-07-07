using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class Repository<T> : ReadOnlyRepository<T>, IRepository<T> where T : class
    {
        public Repository(DbSet<T> dbSet) : base(dbSet)
        {
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
