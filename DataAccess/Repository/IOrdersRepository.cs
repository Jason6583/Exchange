using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface IOrdersRepository : IOrdersReadOnlyRepository
    {
        PlaceOrderResult PlaceOrder(int userId, short marketId, bool side, long quantity, decimal rate, decimal stopRate, short orderType, short orderCondition, DateTime? cancelOn, long? icebergQuantity);
    }
}
