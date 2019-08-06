using Entity;

namespace DataAccess.Repository
{
    public interface IMarketRepository : IRepository<Market>, IMarketReadOnlyRepository
    {
    }
}
