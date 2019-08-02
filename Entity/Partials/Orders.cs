using Entity.Partials;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public partial class Orders
    {
        public OrderType OrderType { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderCondition OrderCondition { get; set; }
    }
}
