using DataAccess.Repository;
using System;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IOrdersRepository OrdersRepository { get; }
        ICurrencyRepository CurrencyRepository { get; }
        IUserCredentialRepository UserCredentialRepository { get; }
        void SaveChanges();
        IUnitOfWork GetNewUnitOfWork();
    }
}
