using Entity.Partials;

namespace Entity
{
    public partial class DepositWithdrawRequest
    {
        public DepositWithdrawRequestType Type { get; set; }
        public DepositWithdrawRequestStatus RequestStatus { get; set; }
    }
}
