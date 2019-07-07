using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace DataAccess.Repository
{
    public interface IBalanceReadOnlyRepository : IReadOnlyRepository<Balance>
    {
        List<Balance> GetBalance(int userId);
    }
}
