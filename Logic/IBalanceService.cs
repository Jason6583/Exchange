using APIModel.ResponseModels;
using Entity;
using System.Collections.Generic;

namespace Logic
{
    public interface IBalanceService
    {
        List<Balance> GetBalance(int userId);
        List<BalanceApiModel> GetBalanceForApi(int userId);
    }
}
