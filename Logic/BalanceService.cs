using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.UnitOfWork;
using Entity;

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
    }
}
