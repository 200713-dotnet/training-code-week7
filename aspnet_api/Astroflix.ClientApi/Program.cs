using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astroflix.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Astroflix.ClientApi
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = CreateHostBuilder(args).Build();

      CreateDatabase(host);
      host.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });

    public static IHost CreateDatabase(IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var context = scope.ServiceProvider.GetRequiredService<AstroflixContext>();

        context.Database.EnsureCreated();
      }

      return host;
    }
  }
}
