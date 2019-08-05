using APIModel;
using APIModel.ResponseModels;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface ICurrencyService
    {
        List<Currency> GetCurrencies();
        List<CurrencyApiModel> GetCurrenciesForApi();
    }
}
