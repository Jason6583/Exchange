using APIModel.ResponseModels;
using Entity;
using System.Collections.Generic;

namespace Logic
{
    public interface IMarketService
    {
        List<Market> GetMarketsWithFee();
        List<MarketApiModel> GetMarketsForApi();
    }
}
