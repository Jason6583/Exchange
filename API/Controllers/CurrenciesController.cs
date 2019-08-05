using System.Collections.Generic;
using APIModel;
using APIModel.ResponseModels;
using Logic;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public CurrenciesController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public IEnumerable<CurrencyApiModel> Get()
        {
            return _currencyService.GetCurrenciesForApi();
        }
    }
}
