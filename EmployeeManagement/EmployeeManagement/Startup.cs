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

            app.UseFileServer(); 
            app.Run(async (context) =>
            {
                throw new Exception("heoola");
                await context.Response.WriteAsync("Hello World"); // 3rd middeware
            });
        }
    }
}
// In this case the output is still "Hello World from first MW2" UI does not display MW3 and reason beind "app.Run" is a terminal middleware,
// and at Terminal middleware request pipelines start returning and doesnt procees furhter.

// new output: Hello World from firs t MW2Hello World from first MW3//// you can see both the middleware got called.

// hello from foo.html this is te output now.

// reasons to why we are not seeing the exception here in output. Output is still"hello from default.html"
// reason being UseFileServer is the combination of both default pagr and static page so out request gets served and then reverse proxy starts, so app.run never gets executed.