using product_api.Brokers;
using product_api.Services;
using product_api.Services.FoundationServices;

namespace product_api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<MySqlStorageBroker>();
            services.AddScoped<IStorageBroker, StorageBroker>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddTransient<IProductService, ProductService>();
            return services;
        }
    }
}
