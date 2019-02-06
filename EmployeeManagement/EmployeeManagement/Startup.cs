using System;
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
                DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 2
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions); // 1st middleware
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

// FLow for exception here.
/* when we try to git localhost:port/ty.html  we start getting exception WHY SO?
 * so intially request came and then middleware and then usedeveloperexceptionpage got registered, and then when the resource ty.html is not found by "UseFIleServer" middleware it passes to the request to
 * next middleware which is
 * throwing the exception.
 *
 * Now with above code change when resource is not found and exceotions is thrown we do not see the developer excption page becasue it is not registered yet. so we should always try to register the exceot
 *
 * with this set up when we visit some unknown url as "http://localhost:52160/io.html then in developer exception pafe that gets opened we see 2 lines of code above and beneath the actual excetion line.
 */
