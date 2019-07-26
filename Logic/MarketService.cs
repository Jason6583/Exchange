using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIModel;
using DataAccess.UnitOfWork;
using Entity;
using Util;

namespace Logic
{
    public class MarketService : IMarketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadOnlyContext _readOnlyContext;
        public MarketService(IUnitOfWork unitOfWork, IReadOnlyContext readOnlyContext)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
        }

        public List<MarketApiModel> GetMarketsForApi()
        {
            return GetMarketsWithFee().Select(x => new MarketApiModel
            {
                CancelAllowed = x.CancelAllowed,
                MakerFeePercent = x.TradeFee.MakerFeePercent,
                Id = x.Id,
                MaxRate = x.MaxRate,
                MinRate = x.MinRate,
                NewOrderAllowed = x.NewOrderAllowed,
                QuantityStepSize = x.QuantityStepSize.ToCoin(),
                QuoteCurrencyId = x.QuoteCurrencyId,
                RateStepSize = x.RateStepSize,
                TakerFeePercent = x.TradeFee.TakerFeePercent,
                TradeCurrencyId = x.TradeCurrencyId,
                MaxQuantity = x.TradeMaxQuantity.ToCoin(),
                MinQuantity = x.TradeMinQuantity.ToCoin()
            }).ToList();
        }

        public List<Market> GetMarketsWithFee()
        {
            return _readOnlyContext.MarketRepository.GetMarketsWithFee();
        }

    }
}
