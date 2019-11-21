using APIModel.RequestModels;
using APIModel.ResponseModels;
using DataAccess.UnitOfWork;
using Entity;
using System;
using System.Collections.Generic;
using Util;

namespace Logic
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadOnlyContext _readOnlyContext;
        public OrderService(IUnitOfWork unitOfWork, IReadOnlyContext readOnlyContext)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
        }

        public Orders FindById(int id)
        {
            return _readOnlyContext.OrdersRepository.Find(id);
        }

        public List<OrderResponseModel> GetOrdersForApi(int userId, int pageNumber = 1, int pageSize = 50)
        {
            return _readOnlyContext.OrdersRepository.GetOrdersForApi(userId, pageNumber, pageSize);
        }

        public BusinessOperationResult<Orders> PlaceOrder(int userId, OrderRequestModel orderRequestModel)
        {
            if (orderRequestModel == null)
                throw new ArgumentNullException(nameof(orderRequestModel));

            using (var uow = _unitOfWork.GetNewUnitOfWork())
            {
                var icebergQuantity = orderRequestModel.IcebergQuantity.HasValue ? orderRequestModel.IcebergQuantity.Value.ToSatoshi() : 0;
                var result = uow.OrdersRepository.PlaceOrder(userId, orderRequestModel.MarketId.Value, orderRequestModel.IsBuy.Value, orderRequestModel.Quantity.Value.ToSatoshi(), orderRequestModel.Rate.Value, orderRequestModel.StopRate.Value, (short)orderRequestModel.OrderType.Value, (short)orderRequestModel.OrderCondition.Value, orderRequestModel.CancelOn, icebergQuantity);
                var bor = new BusinessOperationResult<Orders> { ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage, Id = result.OrderId };
                if (result.ErrorCode == 0)
                    bor.Entity = uow.OrdersRepository.Find(result.OrderId);
                return bor;
            }
        }
    }
}
