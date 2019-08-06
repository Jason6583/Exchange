using Entity;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface ICurrencyReadOnlyRepository : IReadOnlyRepository<Currency>
    {
        List<Currency> GetAllCurrencies();
    }
}
