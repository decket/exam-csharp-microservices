using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ExamService.Data;

namespace ExamService
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      Configuration = configuration;
      _env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {

      Console.WriteLine("--> Using SqlServer Db");
      services.AddDbContext<AppDbContext>(opt =>
          opt.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));

      services.AddScoped<ISalesOrderDetailsRepo, SalesOrderDetailsRepo>();

      // services.AddHttpClient<IBookingnDataClient, HttpBookingDataClient>();
      services.AddControllers();
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlatformService", Version = "v1" });
      });

      Console.WriteLine($"--> BookingService Endpoint {Configuration["BookingService"]}");
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PlatformService v1"));
      }

      //app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();

        endpoints.MapGet("/protos/exam.proto", async context =>
              {
                await context.Response.WriteAsync(File.ReadAllText("Protos/platforms.proto"));
              });
      });

      PrepareDatabase.PrepPopulation(app, env.IsProduction());
    }
  }
}