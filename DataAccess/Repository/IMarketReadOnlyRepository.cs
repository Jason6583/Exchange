using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace DataAccess.Repository
{
    public interface IMarketReadOnlyRepository
    {
        List<Market> GetMarketsWithFee();
    }
}
