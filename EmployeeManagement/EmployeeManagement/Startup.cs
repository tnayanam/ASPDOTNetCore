﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // this is where all the middleware goes.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // 1st middleware
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World from first MW2"); // 2nd middle ware
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World from first MW3"); // 3rd middleware
            });
        }
    }
}
// In this case the output is still "Hello World from first MW2" UI does not display MW3 and reason beind "app.Run" is a terminal middleware,
// and at Terminal middleware request pipelines start returning and doesnt procees furhter.