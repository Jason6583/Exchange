using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface IOrdersRepository : IOrdersReadOnlyRepository
    {
        PlaceOrderResult PlaceOrder();
    }
}
