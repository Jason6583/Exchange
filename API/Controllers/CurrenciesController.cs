using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.UnitOfWork;
using Entity;
using Logic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API
{
    [Route("api/[controller]")]
    public class CurrenciesController : Controller
    {
        private readonly ICurrencyService _currencyService;
        public CurrenciesController(ExchangeContext dbcontext)//ICurrencyService currencyService)
        {
            //_currencyService = currencyService;
            //var dbcontext = new ExchangeContext("Host=localhost;Database=Exchange;Username=postgres;Password=root", new GlobalQueryFilterRegisterer());
            _currencyService = new CurrencyService(new UnitOfWork(dbcontext), new ReadOnlyContext(dbcontext));
        }

        [HttpGet]
        public IEnumerable<Currency> Get()
        {
            return _currencyService.GetCurrencies();
        }
    }
}
