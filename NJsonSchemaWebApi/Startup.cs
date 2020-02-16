using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NJsonSchemaWebApi.Interfaces;
using NJsonSchemaWebApi.Services;

namespace NJsonSchemaWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IJsonSchemaService, JsonSchemaService>();
            services.AddScoped<ICSharpService, CSharpService>();
            services.AddScoped<ITypeScriptService, TypeScriptService>();
            services.AddScoped<IYamlSchemaService, YamlSchemaService>();
            services.AddScoped<IJsonService, JsonService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
