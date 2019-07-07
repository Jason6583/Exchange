using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface IReadOnlyRepository<T>
    {
        T Find(params object[] keys);
    }
}
