using System;
using System.Collections.Generic;
using System.Text;
using APIModel;
using APIModel.ResponseModels;
using Entity;

namespace Logic
{
    public interface IBalanceService
    {
        List<Balance> GetBalance(int userId);
        List<BalanceApiModel> GetBalanceForApi(int userId);
    }
}
