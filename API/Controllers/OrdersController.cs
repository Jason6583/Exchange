using APIModel.RequestModels;
using APIModel.ResponseModels;
using Entity;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public List<OrderResponseModel> Get([FromQuery]PageModel pageModel)
        {
            return _orderService.GetOrdersForApi(4, pageModel?.PageNumber ?? 1, pageModel?.PageSize ?? 50);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Orders), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Orders> Post([FromBody]OrderRequestModel order)
        {
            var result = _orderService.PlaceOrder(4, order);
            if (result.ErrorCode != 0)
            {
                ModelState.AddModelError("", result.ErrorMessage);
                return BadRequest(ModelState);
            }
            return result.Entity;
        }
    }
}
