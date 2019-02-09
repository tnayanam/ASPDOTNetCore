using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GlobeMantics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}


// Ok so I wanted to add bootstrap and all, for that just right clik on the solution and add npm configuration
// file, and then type the bootstrap thing as seen in packae.json file. the bootstrap gets installed as soon as you save
// the file, also when you see the hidden files from solution explorer you cn see a folder called node_modules
// where you can see bootstarp files, just copy the file syou need a paste it in the wwwroot folder.

    /*
     *Suppose you want to deploy minified version, jsut create a json file and add it in the solution
     * directory and then name it as bundleconfig.json and add the content as shown in that file. and then
     * go to view -> other windowws -> task runner and then clikc on Update all files and you should see those
     * files in wwwroot folder.
     */