using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Trade
    {
        public Trade()
        {
            TradeTransaction = new HashSet<TradeTransaction>();
        }

        public int Id { get; set; }
        public long Quantity { get; set; }
        public decimal Rate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int OrderId { get; set; }
        public bool IsMaker { get; set; }
        public long Fee { get; set; }
        public short FeeCurrencyId { get; set; }

        public virtual Currency FeeCurrency { get; set; }
        public virtual Orders Order { get; set; }
        public virtual ICollection<TradeTransaction> TradeTransaction { get; set; }
    }
}
