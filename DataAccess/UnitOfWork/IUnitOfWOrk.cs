using DataAccess.Repository;
using System;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IOrdersRepository OrdersRepository { get; }

        void SaveChanges();
        IUnitOfWork GetNewUnitOfWork();
    }
}
