using System;
using System.Collections.Generic;
using System.Text;

namespace APIModel
{
    public class CurrencyApiModel
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal MinDepositAmount { get; set; }
        public decimal MinWithdrawAmount { get; set; }
        public decimal MaxDepositAmount { get; set; }
        public decimal MaxWithdrawAmount { get; set; }
        public decimal DailyMaxDepositAmount { get; set; }
        public decimal DailyMaxWithdrawAmount { get; set; }
    }
}
