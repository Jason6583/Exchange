using System.Collections.Generic;
using APIModel;
using APIModel.ResponseModels;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketsController : ControllerBase
    {
        private readonly IMarketService _marketService;
        public MarketsController(IMarketService marketService)
        {
            _marketService = marketService;
        }


        [HttpGet]
        public List<MarketApiModel> Get()
        {
            return _marketService.GetMarketsForApi();
        }
    }
}
