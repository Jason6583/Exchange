using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Transaction
    {
        public Transaction()
        {
            OrdersTransaction = new HashSet<OrdersTransaction>();
            TradeTransaction = new HashSet<TradeTransaction>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public long Amount { get; set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public short CurrencyId { get; set; }
        public long AbsoluteAmount { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<OrdersTransaction> OrdersTransaction { get; set; }
        public virtual ICollection<TradeTransaction> TradeTransaction { get; set; }
    }
}
