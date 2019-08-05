using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public enum OrderType : short
    {
        Limit = 1,
        StopLimit = 2,
        Market = 3,
        StopLoss = 4
    }
}
