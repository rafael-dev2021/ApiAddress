using ApiAddressSearchBackEnd.Models;
using ApiAddressSearchBackEnd.Providers;
using ApiAddressSearchBackEnd.Providers.Interfaces;
using ApiAddressSearchBackEnd.Services;
using ApiAddressSearchBackEnd.Services.Interfaces;

namespace ApiAddressSearchBackEnd.Extensions
{
    public static class DependecyInjectionApiAddressDatabase
    {
        public static IServiceCollection AddApiAddressDatabase(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<MongoDbConfiguration>(configuration.GetSection("ApiAddressDatabase"));
            services.AddSingleton<IAddressService,AddressService>();
            services.AddSingleton<IHttpClient, HttpClientMicrosoft>();
            return services;
        }
    }
}
