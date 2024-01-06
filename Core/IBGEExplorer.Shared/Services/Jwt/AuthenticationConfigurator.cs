using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IBGEExplorer.Shared.Services.Jwt;

public static class AuthenticationConfigurator
{


    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "Api-IBGEExplorer-Issuer",
                    ValidAudience = "Api-IBGEExplorer-Audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.secret)),
                    ClockSkew = TimeSpan.Zero
                };
            });

        return services;
    }



    #region Authentication old

    //public static void AuthenticationConfigure(this IServiceCollection services)
    //{
    //    services.AddAuthentication(x =>
    //        {
    //            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //        })
    //        .AddJwtBearer(options =>
    //        {
    //            options.TokenValidationParameters = new TokenValidationParameters
    //            {
    //                ValidateIssuer = false,
    //                ValidateAudience = false,
    //                ValidateLifetime = true,
    //                ValidateIssuerSigningKey = true,
    //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.secret))
    //            };
    //        });
    //}

    #endregion
}