using Microsoft.EntityFrameworkCore;
using System;

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
