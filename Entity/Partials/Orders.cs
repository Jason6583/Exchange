using Entity.Partials;

namespace Entity
{
    public partial class Orders
    {
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderCondition OrderCondition { get; set; }
    }
}
