using APIModel.ResponseModels;
using DataAccess.UnitOfWork;
using Entity;
using System.Collections.Generic;
using System.Linq;
using Util;

namespace Logic
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReadOnlyContext _readonlyContext;
        public CurrencyService(IUnitOfWork unitOfWork, IReadOnlyContext readOnlyContext)
        {
            _unitOfWork = unitOfWork;
            _readonlyContext = readOnlyContext;
        }

        public List<Currency> GetCurrencies()
        {
            return _readonlyContext.CurrencyRepository.GetAllCurrencies();
        }

        public List<CurrencyApiModel> GetCurrenciesForApi()
        {
            return _readonlyContext.CurrencyRepository.GetAllCurrencies()
                .Select(x => new CurrencyApiModel
                {
                    Code = x.Code,
                    DailyMaxDepositAmount = x.DailyMaxDepositAmount.ToCoin(),
                    DailyMaxWithdrawAmount = x.DailyMaxWithdrawAmount.ToCoin(),
                    Id = x.Id,
                    MaxDepositAmount = x.MaxDepositAmount.ToCoin(),
                    MaxWithdrawAmount = x.MaxWithdrawAmount.ToCoin(),
                    MinDepositAmount = x.MinDepositAmount.ToCoin(),
                    MinWithdrawAmount = x.MinWithdrawAmount.ToCoin(),
                    Name = x.Name
                }).ToList();
        }
    }
}
