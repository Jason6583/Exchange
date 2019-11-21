using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Market
    {
        public short Id { get; set; }
        public short TradeCurrencyId { get; set; }
        public short QuoteCurrencyId { get; set; }
        public DateTime TradingStart { get; set; }
        public DateTime TradingEnd { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long TradeMinQuantity { get; set; }
        public decimal MinRate { get; set; }
        public decimal MaxRate { get; set; }
        public bool NewOrderAllowed { get; set; }
        public bool CancelAllowed { get; set; }
        public long TradeMaxQuantity { get; set; }
        public long QuantityStepSize { get; set; }
        public short TradeFeeId { get; set; }
        public decimal RateStepSize { get; set; }
        public string TradingHaltedReason { get; set; }
        public bool? MarketOrderAllowed { get; set; }
        public bool? StopLimitOrderAllowed { get; set; }
        public bool? StopLossOrderAllowed { get; set; }
        public bool? GoodTillDateOrderAllowed { get; set; }
        public bool? FillOrKillOrderAllowed { get; set; }
        public bool? BookOrCancelAllowed { get; set; }
        public bool? ImmediateOrCancelAllowed { get; set; }

        public virtual Currency QuoteCurrency { get; set; }
        public virtual Currency TradeCurrency { get; set; }
        public virtual TradeFeeHistory TradeFee { get; set; }
    }
}
