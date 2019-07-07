using Entity.Partials;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public partial class DepositWithdrawRequest
    {
        public DepositWithdrawRequestType Type { get; set; }
        public DepositWithdrawRequestStatus RequestStatus { get; set; }
    }
}
