using Entity;

namespace DataAccess.Repository
{
    public interface ICurrencyRepository : IRepository<Currency>, ICurrencyReadOnlyRepository
    {
    }
}
