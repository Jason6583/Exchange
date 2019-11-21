using Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    class MarketRepository : Repository<Market>, IMarketRepository
    {
        public MarketRepository(DbSet<Market> markets) : base(markets)
        {

        }

        public List<Market> GetMarketsWithFee()
        {
            var v = DbSet.Include(x => x.TradeFee).ToList();
            return v;
        }
    }
}
