﻿using System;
using System.Collections.Generic;
using System.Text;
using APIModel;
using Entity;

namespace Logic
{
    public interface IMarketService
    {
        List<Market> GetMarketsWithFee();
        List<MarketApiModel> GetMarketsForApi();
    }
}
