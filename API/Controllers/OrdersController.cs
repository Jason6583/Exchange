using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using APIModel.RequestModels;
using APIModel.ResponseModels;
using Entity;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
