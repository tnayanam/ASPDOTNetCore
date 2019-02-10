﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globemantics.Services;
using GlobeMantics.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GlobeMantics
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IConferenceService, ConferenceMemoryService>(); // Dependency Injection
            services.AddSingleton<IProposalService, ProposalMemoryService>(); // Dependency Injection
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Conference}/{action=Index}/{id?}"
                    );
                });
        }
    }
}

// Now we need to tell that whenever I am using the Interface of proposal and Conference I need to pass Object instance of Conference Memory Service and Proposal Memory Service.

