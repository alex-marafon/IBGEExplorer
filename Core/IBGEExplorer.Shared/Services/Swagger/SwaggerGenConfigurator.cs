using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IBGEExplorer.Shared.Services.Swagger;
public static class SwaggerGenConfigurator
{
    public static void SwaggerConfigure(this IServiceCollection services)
    {
        //services.AddSwaggerGen(x =>
        //{
        //    x.SwaggerDoc("v1", new OpenApiInfo
        //    {
        //        Title = "IBGEExplorer",
        //        Description = "Developed by Desafio Balta",
        //        Contact = new OpenApiContact { Name = "Time A", Email = "timeA@gmail.com" },
        //        License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
        //    });

        //    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //    {
        //        Description = "Inform the token: Bearer {token}",
        //        Name = "Authorization",
        //        Scheme = "Bearer",
        //        BearerFormat = "JWT",
        //        In = ParameterLocation.Header,
        //        Type = SecuritySchemeType.ApiKey
        //    });

        //    x.AddSecurityRequirement(new OpenApiSecurityRequirement
        //    {
        //        {
        //            new OpenApiSecurityScheme
        //            {
        //                Reference = new OpenApiReference
        //                {
        //                    Type = ReferenceType.SecurityScheme,
        //                    Id = "Bearer"
        //                }
        //            },
        //            new string[] {}
        //        }
        //    });
        //});

    }
}
