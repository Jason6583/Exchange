using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class ReceivingAddress
    {
        public ReceivingAddress()
        {
            SendReceiveTransaction = new HashSet<SendReceiveTransaction>();
        }

        public int Id { get; set; }
        public string Address { get; set; }
        public int? UserId { get; set; }
        public short CurrencyId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public short PartitionId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<SendReceiveTransaction> SendReceiveTransaction { get; set; }
    }
}
