using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    class MarketRepository : Repository<Market>, IMarketRepository
    {
        public MarketRepository(DbSet<Market> markets) : base(markets)
        {

        }

        public List<Market> GetMarketsWithFee()
        {
            var v = _dbSet.Include(x => x.TradeFee).ToList();
            return v;
        }
    }
}
