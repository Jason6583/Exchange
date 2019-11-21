using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace Entity
{
    public partial class ExchangeContext : DbContext
    {
        private readonly string _connectionString;
        private readonly IGlobalQueryFilterRegisterer _globalQueryFilterRegisterer; //TODO add unit test to check for _globalQueryFilterRegisterer executed during OnModelCreating
        public ExchangeContext(IGlobalQueryFilterRegisterer globalQueryFilterRegisterer, string connectionSting)
        {
            _globalQueryFilterRegisterer = globalQueryFilterRegisterer ?? throw new ArgumentNullException(nameof(globalQueryFilterRegisterer));
            _connectionString = connectionSting ?? throw new ArgumentNullException(nameof(connectionSting));
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null)
                throw new ArgumentNullException(nameof(optionsBuilder));

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                    .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            _globalQueryFilterRegisterer.RegisterGlobalQueryFilters(modelBuilder);
        }
    }
}
