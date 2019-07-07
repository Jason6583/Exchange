using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface ICurrencyReadOnlyRepository : IReadOnlyRepository<Currency>
    {
        List<Currency> GetAllCurrencies();
    }
}
