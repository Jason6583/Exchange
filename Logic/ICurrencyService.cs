using APIModel.ResponseModels;
using Entity;
using System.Collections.Generic;

namespace Logic
{
    public interface ICurrencyService
    {
        List<Currency> GetCurrencies();
        List<CurrencyApiModel> GetCurrenciesForApi();
    }
}
