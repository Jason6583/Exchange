using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
    public class OrdersRepository : Repository<Orders>, IOrdersReadOnlyRepository, IOrdersRepository
    {
        public OrdersRepository(DbSet<Orders> dbSet) : base(dbSet)
        {
        }

        public IQueryable<Orders> GetRecentOrders(int userId, short market)
        {
            return _dbSet.Where(x => x.UserId == userId && x.MarketId == market);
        }

        public PlaceOrderResult PlaceOrder()
        {
            return new PlaceOrderResult();
        }
    }
}
