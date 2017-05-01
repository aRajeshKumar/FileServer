using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace ASPNetcoreServer
{
    class Program
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    context.Context.Response.Headers.Add("content-disposition", "attachment; a.dll1");
                }
            });
        }

        static void Main(string[] args)
        {
            new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}