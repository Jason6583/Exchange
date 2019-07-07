using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Orders
    {
        public Orders()
        {
            Trade = new HashSet<Trade>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public long Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal StopRate { get; set; }
        public bool Side { get; set; }
        public long QuantityRemaining { get; set; }
        public short MarketId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Trade> Trade { get; set; }
    }
}
