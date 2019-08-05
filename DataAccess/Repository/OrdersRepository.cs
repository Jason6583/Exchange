using APIModel.ResponseModels;
using Entity;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Util;

namespace DataAccess.Repository
{
    public class OrdersRepository : Repository<Orders>, IOrdersReadOnlyRepository, IOrdersRepository
    {
        private readonly DbContext _dbContext;
        public OrdersRepository(DbSet<Orders> dbSet, DbContext dbContext) : base(dbSet)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Orders> GetRecentOrders(int userId, short market)
        {
            return _dbSet.Where(x => x.UserId == userId && x.MarketId == market);
        }

        public PlaceOrderResult PlaceOrder(int userId, short marketId, bool side, long quantity, decimal rate, decimal stopRate, short orderType, short orderCondition, DateTime? cancelOn, long? icebergQuantity)
        {
            string sql = "CALL place_order(@userId, @marketId, @side, @quantity, @rate, @stopRate, @orderType, @orderCondition, @cancelOn, @icebergQuantity, @errorCode, @errorMessage, @orderId)";
            var pUserId = InParam("@userId", userId);
            var pMarketId = InParam("@marketId", marketId);
            var pSide = InParam("@side", side);
            var pQuantity = InParam("@quantity", quantity);
            var pRate = InParam("@rate", rate);
            var pStopRate = InParam("@stopRate", stopRate);
            var pOrderCondition = InParam("@orderCondition", orderCondition);
            var pCancelOn = InParam("@cancelOn", cancelOn);
            var pIcebergQuantity = InParam("@icebergQuantity", icebergQuantity);
            var pOrderType = InParam("@orderType", orderType);
            var pErrorCode = InOutParamInt("@errorCode");
            var pErrorMessage = InOutParamString("@errorMessage");
            var pOrderId = InOutParamInt("@orderId");
            _dbContext.Database.ExecuteSqlCommand(sql, pUserId, pMarketId, pSide, pQuantity, pRate, pStopRate, pOrderType, pOrderCondition, pCancelOn, pIcebergQuantity, pErrorCode, pErrorMessage, pOrderId);
            return new PlaceOrderResult()
            {
                ErrorCode = (int)pErrorCode.Value,
                ErrorMessage = pErrorMessage.Value == DBNull.Value ? null : (string)pErrorMessage.Value,
                OrderId = pOrderId.Value == DBNull.Value ? null : (int?)pOrderId.Value
            };
        }

        public List<OrderResponseModel> GetOrdersForApi(int userId, int pageNumber = 1, int pageSize = 50)
        {
            return _dbSet.Where(x => x.UserId == userId).OrderBy(x => x.CreatedOn).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(x => new OrderResponseModel
                {
                    CancelOn = x.CancelOn,
                    CreatedOn = x.CreatedOn,
                    Fee = x.Fee.ToCoin(),
                    FeeCurrencyId = x.FeeCurrencyId,
                    Id = x.Id,
                    IsBuy = x.Side,
                    LockedBalance = x.LockedBalance.ToCoin(),
                    MarketId = x.MarketId,
                    OrderCondition = x.OrderCondition,
                    OrderStatus = x.OrderStatus,
                    OrderType = x.OrderType,
                    Quantity = x.Quantity.ToCoin(),
                    QuantityExecuted = x.QuantityExecuted.ToCoin(),
                    QuantityRemaining = x.QuantityRemaining.ToCoin(),
                    Rate = x.Rate,
                    StopRate = x.StopRate,
                    TradeFeeId = x.TradeFeeId,
                    IcebergQuantity = x.IcebergQuantity.HasValue ? x.IcebergQuantity.Value.ToCoin() : (decimal?)null
                }).ToList();
        }
    }
}
