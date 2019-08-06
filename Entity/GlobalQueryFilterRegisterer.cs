using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class GlobalQueryFilterRegisterer : IGlobalQueryFilterRegisterer
    {
        public void RegisterGlobalQueryFilters(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Balance>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Currency>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<DepositWithdrawRequest>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<KycInfo>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Market>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Orders>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<ReceivingAddress>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<SendingAddress>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<SendReceiveTransaction>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Trade>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<TradeHistory>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Transaction>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Users>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
