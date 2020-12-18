using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using {{ cookiecutter.dotnet_namespace }}.Services

namespace {{ cookiecutter.dotnet_namespace }}.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // The following line enables Application Insights telemetry collection.
      services.AddApplicationInsightsTelemetry();

      services.AddCors(options =>
          {
            options.AddDefaultPolicy(
                                  builder =>
                                  {
                                    builder.WithOrigins("http://localhost:3000", "https://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                                  });
          });
      services.AddControllers()
          .AddJsonOptions(options =>
          {
            options.JsonSerializerOptions.IgnoreNullValues = true;
          });

      // Register the Swagger generator, defining 1 or more Swagger documents   
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Customer analysis API",
          Description = "Martin & Servera {{cookiecutter.component_id}} API",
        });
      });

      // register the scope authorization handler
      services.AddScoped<IService, Service>();
      services.AddScoped<IRepository, Repository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "{{cookiecutter.component_id}} API V1");
      });

      app.UseRouting();

      app.UseCors();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
