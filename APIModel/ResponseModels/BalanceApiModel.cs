using System;
using System.Collections.Generic;
using System.Text;

namespace APIModel
{
    public class BalanceApiModel
    {
        public int CurrencyId { get; set; }
        public decimal SpendableBalance { get; set; }
        public decimal LockedBalance { get; set; }
    }
}
