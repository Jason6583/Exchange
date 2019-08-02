using System;
using System.Collections.Generic;

namespace Entity
{
    public partial class Currency
    {
        public Currency()
        {
            Balance = new HashSet<Balance>();
            DepositWithdrawRequest = new HashSet<DepositWithdrawRequest>();
            MarketQuoteCurrency = new HashSet<Market>();
            MarketTradeCurrency = new HashSet<Market>();
            ReceivingAddress = new HashSet<ReceivingAddress>();
            SendReceiveTransaction = new HashSet<SendReceiveTransaction>();
            SendingAddress = new HashSet<SendingAddress>();
            Trade = new HashSet<Trade>();
            Transaction = new HashSet<Transaction>();
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long MinDepositAmount { get; set; }
        public long MinWithdrawAmount { get; set; }
        public long MaxDepositAmount { get; set; }
        public long MaxWithdrawAmount { get; set; }
        public long DailyMaxDepositAmount { get; set; }
        public long DailyMaxWithdrawAmount { get; set; }
        public bool IsVirtual { get; set; }
        public bool DepositAllowed { get; set; }
        public bool WithdrawalAllowed { get; set; }
        public string DepositHaltedReason { get; set; }
        public string WithdrawHaltedReason { get; set; }

        public virtual ICollection<Balance> Balance { get; set; }
        public virtual ICollection<DepositWithdrawRequest> DepositWithdrawRequest { get; set; }
        public virtual ICollection<Market> MarketQuoteCurrency { get; set; }
        public virtual ICollection<Market> MarketTradeCurrency { get; set; }
        public virtual ICollection<ReceivingAddress> ReceivingAddress { get; set; }
        public virtual ICollection<SendReceiveTransaction> SendReceiveTransaction { get; set; }
        public virtual ICollection<SendingAddress> SendingAddress { get; set; }
        public virtual ICollection<Trade> Trade { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
