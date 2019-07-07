using System;
using System.Collections.Generic;
using System.Text;

namespace Ticker
{
    class CandleStickComparer : IComparer<CandleStick>
    {
        public int Compare(CandleStick x, CandleStick y)
        {
            return x.Start - y.Start;
        }
    }
}
