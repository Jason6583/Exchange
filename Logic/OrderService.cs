using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.UnitOfWork;
using Entity;

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

        public BusinessOperationResult<Orders> PlaceOrder()
        {
            using (var uow = _unitOfWork.GetNewUnitOfWork())
            {
                var result = uow.OrdersRepository.PlaceOrder();
                var bor = new BusinessOperationResult<Orders> { ErrorCode = result.ErrorCode, ErrorMessage = result.ErrorMessage, Id = result.OrderId };
                if (result.ErrorCode == 0)
                    bor.Entity = uow.OrdersRepository.Find(result.OrderId);
                return bor;
            }
        }
    }
}
