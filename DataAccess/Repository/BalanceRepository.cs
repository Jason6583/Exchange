using Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class BalanceRepository : Repository<Balance>, IBalanceRepository
    {
        public BalanceRepository(DbSet<Balance> dbSet) : base(dbSet)
        {

        }

        public List<Balance> GetBalance(int userId)
        {
            return DbSet.Where(x => x.UserId == userId).ToList();
        }
    }
}
