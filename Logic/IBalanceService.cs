using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace Logic
{
    public interface IBalanceService
    {
        List<Balance> GetBalance(int userId);
    }
}
