using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APIModel;
using DataAccess.UnitOfWork;
using Entity;
using Util;

namespace Logic
{
    public class BalanceService : IBalanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadOnlyContext _readOnlyContext;
        public BalanceService(IUnitOfWork unitOfWork, IReadOnlyContext readOnlyContext)
        {
            _unitOfWork = unitOfWork;
            _readOnlyContext = readOnlyContext;
        }

        public List<Balance> GetBalance(int userId)
        {
            return _readOnlyContext.BalanceRepository.GetBalance(userId);
        }

        public List<BalanceApiModel> GetBalanceForApi(int userId)
        {
            return _readOnlyContext.BalanceRepository.GetBalance(userId)
                .Select(x => new BalanceApiModel
                {
                    CurrencyId = x.CurrencyId,
                    LockedBalance = x.LockedBalance.ToCoin(),
                    SpendableBalance = x.SpendableBalance.ToCoin()
                }).ToList();
        }

    }
}
