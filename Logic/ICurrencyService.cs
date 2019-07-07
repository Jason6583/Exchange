using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface ICurrencyService
    {
        List<Currency> GetCurrencies();
    }
}
