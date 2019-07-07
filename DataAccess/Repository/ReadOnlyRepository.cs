using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;

        public ReadOnlyRepository(DbSet<T> dbSet)
        {
            _dbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
        }

        public T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }
    }
}
