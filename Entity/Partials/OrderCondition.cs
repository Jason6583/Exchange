using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Partials
{
    public enum OrderCondition : byte
    {
        None = 0,
        ImmediateOrCancel = 1,
        BookOrCancel = 2,
        FillOrKill = 4,
    }
}
