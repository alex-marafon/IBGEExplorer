using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SharedContext.Services.Jwt.Contracts;
using System.Text;

namespace SharedContext.Services.Jwt;

public class AuthenticationConfigurator : IAuthenticationConfigurator
{
    public void AuthenticationConfigure(IServiceCollection services)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.secret))
                };
                
                //Verificar com time se é viavel devolver ao usuario, notificar no discord ou ambos

                //options.Events = new JwtBearerEvents
                //{
                //    OnAuthenticationFailed = context =>
                //    {
                //        Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                //        return Task.CompletedTask;
                //    },
                //    OnTokenValidated = context =>
                //    {
                //        Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                //        return Task.CompletedTask;
                //    }
                //};
            });
    }
}

