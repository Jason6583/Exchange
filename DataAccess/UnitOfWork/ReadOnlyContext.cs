using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.UnitOfWork
{
    public class ReadOnlyContext : IReadOnlyContext
    {
        private readonly DbContext _dbContext;
        public ReadOnlyContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IOrdersReadOnlyRepository _ordersRepository;
        private ICurrencyReadOnlyRepository _currencyRepository;
        private IBalanceReadOnlyRepository _balanceRepository;
        private IMarketReadOnlyRepository _marketRepository;
        public IOrdersReadOnlyRepository OrdersRepository
        {
            get
            {
                if (_ordersRepository == null)
                    _ordersRepository = new OrdersRepository(_dbContext.Set<Orders>(), _dbContext);

                return _ordersRepository;
            }
        }

        public ICurrencyReadOnlyRepository CurrencyRepository
        {
            get
            {
                if (_currencyRepository == null)
                    _currencyRepository = new CurrencyRepository(_dbContext.Set<Currency>());

                return _currencyRepository;
            }
        }

        public IBalanceReadOnlyRepository BalanceRepository
        {
            get
            {
                if (_balanceRepository == null)
                    _balanceRepository = new BalanceRepository(_dbContext.Set<Balance>());

                return _balanceRepository;
            }
        }

        public IMarketReadOnlyRepository MarketRepository
        {
            get
            {
                if (_marketRepository == null)
                    _marketRepository = new MarketRepository(_dbContext.Set<Market>());

                return _marketRepository;
            }
        }
    }
}
