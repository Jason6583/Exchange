namespace APIModel.ResponseModels
{
    public class BalanceApiModel
    {
        public int CurrencyId { get; set; }
        public decimal SpendableBalance { get; set; }
        public decimal LockedBalance { get; set; }
    }
}
