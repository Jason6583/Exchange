using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class TradeHistory
    {
        public int Id { get; set; }
        public short MarketId { get; set; }
        public long Quantity { get; set; }
        public decimal Rate { get; set; }
        public int BidOrderId { get; set; }
        public int AskOrderId { get; set; }
        public int MakerOrderId { get; set; }
        public int TakerOrderId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
