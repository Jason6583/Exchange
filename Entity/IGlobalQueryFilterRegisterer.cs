using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public interface IGlobalQueryFilterRegisterer
    {
        void RegisterGlobalQueryFilters(ModelBuilder modelBuilder);
    }
}
