using Entity;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public interface IBalanceReadOnlyRepository : IReadOnlyRepository<Balance>
    {
        List<Balance> GetBalance(int userId);
    }
}
