using Entity;
using Entity.Partials;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIModel.RequestModels
{
    public class OrderRequestModel
    {
        public short? MarketId { get; set; }
        public decimal? Rate { get; set; }
        public decimal? StopRate { get; set; }
        public decimal? Quantity { get; set; }
        public bool? IsBuy { get; set; }
        public OrderType? OrderType { get; set; }
        public OrderCondition? OrderCondition { get; set; }
        public DateTime? CancelOn { get; set; }
    }
}
