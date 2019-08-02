using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class TradeFeeHistory
    {
        public TradeFeeHistory()
        {
            Market = new HashSet<Market>();
            Orders = new HashSet<Orders>();
        }

        public short Id { get; set; }
        public decimal MakerFeePercent { get; set; }
        public decimal TakerFeePercent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Label { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Market> Market { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
