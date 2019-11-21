using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess.Repository
{
    public class ReadOnlyRepository<T> : IReadOnlyRepository<T> where T : class
    {
        protected DbSet<T> DbSet { get; }

        public ReadOnlyRepository(DbSet<T> dbSet)
        {
            DbSet = dbSet ?? throw new ArgumentNullException(nameof(dbSet));
        }

        public T Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }
    }
}
