using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public static class Extension
    {
        public static long ToSatoshi(this decimal coin)
        {
            return (long)(coin * 100000000);
        }

        public static decimal ToCoin(this long satoshi)
        {
            return ((decimal)satoshi) / 100000000;
        }
    }
}
