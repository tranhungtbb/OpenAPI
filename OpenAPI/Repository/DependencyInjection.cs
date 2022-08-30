namespace OpenAPI.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection UseDependencyInjection(this IServiceCollection services)
        {

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
