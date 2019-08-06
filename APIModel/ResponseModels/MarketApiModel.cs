namespace APIModel.ResponseModels
{
    public class MarketApiModel
    {
        public int Id { get; set; }
        public short TradeCurrencyId { get; set; }
        public short QuoteCurrencyId { get; set; }
        public decimal MinQuantity { get; set; }
        public decimal MinRate { get; set; }
        public decimal MaxRate { get; set; }
        public bool NewOrderAllowed { get; set; }
        public bool CancelAllowed { get; set; }
        public decimal MaxQuantity { get; set; }
        public decimal QuantityStepSize { get; set; }
        public decimal RateStepSize { get; set; }
        public decimal MakerFeePercent { get; set; }
        public decimal TakerFeePercent { get; set; }
    }
}
