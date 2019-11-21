using DataAccess.UnitOfWork;
using Entity;
using Logic;
using Microsoft.Extensions.DependencyInjection;

namespace Auth
{
    public static class ConfigureServiceExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddSingleton<IGlobalQueryFilterRegisterer, GlobalQueryFilterRegisterer>();
            services.AddScoped<ExchangeContext>(x => new ExchangeContext(new GlobalQueryFilterRegisterer(), "Host=localhost;Database=Exchange;Username=postgres;Password=root"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IReadOnlyContext, ReadOnlyContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
