using Microsoft.OpenApi;

namespace Payments.Api.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddApiSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "Enter your JWT token (just the token, no need to type 'Bearer' first)"
            });

            options.AddSecurityRequirement(document => new()
            {
                [new("Bearer", document)] = []
            });
        });

        return services;
    }
}
