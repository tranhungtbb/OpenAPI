using NSwag;
using NSwag.Generation.Processors.Security;

namespace OpenAPI.Middleware
{
    public static class SwaggerDocument
    {
        public static IServiceCollection AddSwaggerDocumentConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Open API";

                configure.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "ToDo API";
                    document.Info.Description = "A simple ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };

                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            return services;
        }

        public static IApplicationBuilder UserSwaggerDocument(this IApplicationBuilder app, IConfiguration configuration) {
            app.UseOpenApi();
            //app.UseSwaggerUi3();
            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
                settings.DocumentPath = "/api/specification.json";
            });
            return app;
        }
    }
}
