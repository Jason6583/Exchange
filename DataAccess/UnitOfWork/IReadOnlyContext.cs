using DataAccess.Repository;

namespace DataAccess.UnitOfWork
{
    public interface IReadOnlyContext
    {
        IOrdersReadOnlyRepository OrdersRepository { get; }
        ICurrencyReadOnlyRepository CurrencyRepository { get; }
        IBalanceReadOnlyRepository BalanceRepository { get; }
        IMarketReadOnlyRepository MarketRepository { get; }
        IUserReadOnlyRepository UserReadOnlyRepository { get; }
        IUserCredentialReadOnlyRepository UserCredentialReadOnlyRepository { get; }
    }
}
