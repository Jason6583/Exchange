using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public interface IGlobalQueryFilterRegisterer
    {
        void RegisterGlobalQueryFilters(ModelBuilder modelBuilder);
    }
}
