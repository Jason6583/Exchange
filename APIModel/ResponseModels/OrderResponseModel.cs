using Entity;
using Entity.Partials;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIModel.ResponseModels
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal StopRate { get; set; }
        public bool IsBuy { get; set; }
        public decimal QuantityRemaining { get; set; }
        public short MarketId { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal QuantityExecuted { get; set; }
        public decimal LockedBalance { get; set; }
        public decimal Fee { get; set; }
        public short FeeCurrencyId { get; set; }
        public short TradeFeeId { get; set; }
        public DateTime? CancelOn { get; set; }
        public decimal? IcebergQuantity { get; set; }
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderCondition OrderCondition { get; set; }

    }
}
