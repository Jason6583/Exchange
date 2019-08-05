using APIModel.ResponseModels;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
    public interface IOrdersReadOnlyRepository : IReadOnlyRepository<Orders>
    {
        IQueryable<Orders> GetRecentOrders(int userId, short market);
        List<OrderResponseModel> GetOrdersForApi(int userId, int pageNumber = 1, int pageSize = 50);
    }
}
