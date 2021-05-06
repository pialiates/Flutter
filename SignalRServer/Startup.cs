using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using SignalRServer.Hubs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(x => true)));
            services.AddControllers();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "aosignalr.aates.site",
                    ValidAudience = "aosignalr.aates.site",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("buraya yazilan key sifrelemek icin yazilmistir sifre keyidir")),
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,
                    LifetimeValidator = (notBefore, expires, tokenToValidate, tokenValidationParametres) => expires != null ? expires > DateTime.UtcNow : false
                };
            });

            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapHub<DenemeHub>("/deneme");
                endpoints.MapHub<LoginHub>("/login");
                endpoints.MapHub<MessageHub>("/message");
            });
        }
    }
}
