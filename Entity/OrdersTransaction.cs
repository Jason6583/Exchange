namespace Entity
{
    public partial class OrdersTransaction
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TransactionId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
