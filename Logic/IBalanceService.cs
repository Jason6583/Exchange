using System;
using System.Collections.Generic;
using System.Text;
using APIModel;
using Entity;

namespace Logic
{
    public interface IBalanceService
    {
        List<Balance> GetBalance(int userId);
        List<BalanceApiModel> GetBalanceForApi(int userId);
    }
}
