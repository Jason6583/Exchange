using Entity;

namespace DataAccess.Repository
{
    public interface IBalanceRepository : IRepository<Balance>, IBalanceReadOnlyRepository
    {
    }
}
