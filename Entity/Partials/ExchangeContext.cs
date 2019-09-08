using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace Entity
{
    public partial class ExchangeContext : DbContext
    {
        private readonly string _connectionString;
        private readonly IGlobalQueryFilterRegisterer _globalQueryFilterRegisterer;
        public ExchangeContext(IGlobalQueryFilterRegisterer globalQueryFilterRegisterer, string connectionSting)
        {
            _globalQueryFilterRegisterer = globalQueryFilterRegisterer ?? throw new ArgumentNullException(nameof(globalQueryFilterRegisterer));
            _connectionString = connectionSting ?? throw new ArgumentNullException(nameof(connectionSting));
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_globalQueryFilterRegisterer == null)
                throw new ArgumentNullException(nameof(_globalQueryFilterRegisterer));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                    .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
            }
        }

        public PlaceOrderResult PlaceOrder(int userId, short marketId, bool side, long quantity, decimal rate, decimal stopRate, OrderType type)
        {
            return null;
        }
    }
}
