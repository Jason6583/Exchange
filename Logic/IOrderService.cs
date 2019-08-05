using APIModel.RequestModels;
using APIModel.ResponseModels;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IOrderService
    {
        Orders FindById(int id);
        BusinessOperationResult<Orders> PlaceOrder(int userId, OrderRequestModel orderRequestModel);
        List<OrderResponseModel> GetOrdersForApi(int userId, int pageNumber = 1, int pageSize = 50);
    }
}
