using System.Collections.Generic;
using APIModel;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly IBalanceService _balanceService;
        public BalancesController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet]
        public IEnumerable<BalanceApiModel> Get()
        {
            return _balanceService.GetBalanceForApi(4);
        }
    }
}
