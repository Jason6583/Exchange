using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class SendReceiveTransaction
    {
        public int Id { get; set; }
        public string BlockchainTransactionId { get; set; }
        public string Address { get; set; }
        public int? ReceivingAddressId { get; set; }
        public int UserId { get; set; }
        public short CurrencyId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long Quantity { get; set; }
        public long Fee { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ReceivingAddress ReceivingAddress { get; set; }
        public virtual Users User { get; set; }
    }
}
