using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class DepositWithdrawRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public long Amount { get; set; }
        public short CurrencyId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual Users User { get; set; }
    }
}
