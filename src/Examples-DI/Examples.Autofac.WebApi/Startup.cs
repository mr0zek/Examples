using System;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Examples.Autofac.WebApi
{
  public class Startup
  {
    public static Action<ContainerBuilder> BuildFunc = f => { };

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();
      app.UseMvc();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
      builder.RegisterModule(new AutofacModule());
      BuildFunc(builder);
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }
  }
}