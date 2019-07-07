using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace DataAccess.Repository
{
    public interface ICurrencyRepository : IRepository<Currency>, ICurrencyReadOnlyRepository
    {
    }
}
