using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public interface IReadOnlyContext
    {
        IOrdersReadOnlyRepository OrdersRepository { get; }
        ICurrencyReadOnlyRepository CurrencyRepository { get; }
        IBalanceReadOnlyRepository BalanceRepository { get; }
        IMarketReadOnlyRepository MarketRepository { get; }
    }
}
