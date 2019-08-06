using Entity;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IMarketReadOnlyRepository
    {
        List<Market> GetMarketsWithFee();
    }
}
