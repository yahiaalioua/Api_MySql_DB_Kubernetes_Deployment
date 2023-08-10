using Microsoft.EntityFrameworkCore;
using product_api.Brokers;
using product_api.Services;
using product_api.Services.FoundationServices;

namespace product_api.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<StorageBroker>(options=>options.UseMySQL(configuration.GetConnectionString("MySqlDbConnStr")!));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();
            services.AddTransient<IProductService, ProductService>();
            return services;
        }
    }
}
