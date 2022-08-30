namespace OpenAPI.Middleware
{
    public static class AppUseCross
    {
        public static IServiceCollection AppAddCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .WithExposedHeaders("Content-Length", "Access-Control-Allow-Origin", "TotalRecords", "Origin")
                    .AllowCredentials()
                    .AllowAnyHeader());
            });
            return services;
        }   
    }
}
