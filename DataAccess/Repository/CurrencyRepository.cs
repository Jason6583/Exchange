using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(DbSet<Currency> dbSet) : base(dbSet)
        {
        }

        public List<Currency> GetAllCurrencies()
        {
            return _dbSet.ToList();
        }
    }
}
