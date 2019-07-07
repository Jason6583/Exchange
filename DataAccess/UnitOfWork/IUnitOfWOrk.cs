using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IOrdersRepository OrdersRepository { get; }

        void SaveChanges();
        IUnitOfWork GetNewUnitOfWork();
    }
}
