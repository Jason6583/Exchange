using DataAccess.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _dbContext;
        private IOrdersRepository _ordersRepository;
        private ICurrencyRepository _currencyRepository;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IOrdersRepository OrdersRepository
        {
            get
            {
                if (_ordersRepository == null)
                    _ordersRepository = new OrdersRepository(_dbContext.Set<Orders>());

                return _ordersRepository;
            }
        }

        public ICurrencyRepository CurrencyRepository
        {
            get
            {
                if (_currencyRepository == null)
                    _currencyRepository = new CurrencyRepository(_dbContext.Set<Currency>());

                return _currencyRepository;
            }
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public IUnitOfWork GetNewUnitOfWork()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            using (_dbContext.Database.BeginTransaction())
            {
                _dbContext.SaveChanges();
            }
        }
    }
}
