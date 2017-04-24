using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using IdentityServer4;

namespace SSO_CORE
{
    public class Startup
    {
        public Startup(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // configure identity server with in-memory stores, keys, clients and scopes
            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.GetUsers());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseIdentityServer();
        }
    }
}
