namespace Entity
{
    public partial class TradeTransaction
    {
        public int Id { get; set; }
        public int TradeId { get; set; }
        public int TransactionId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Trade Trade { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
