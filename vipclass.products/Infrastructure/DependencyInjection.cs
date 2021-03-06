using Microsoft.Extensions.DependencyInjection;
using vipclass.products.Repository;
using vipclass.products.Repository.Interface;

namespace vipclass.products.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICoursesRepository, CoursesRepository>();
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddTransient<ICoinsRepository, CoinsRepository>();
            return services;
        }
    }
}
