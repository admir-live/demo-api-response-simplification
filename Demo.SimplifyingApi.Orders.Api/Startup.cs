using Demo.SimplifyingApi.Data.Convertors;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Mutable.Process.Infrastructure.Database;

namespace Demo.SimplifyingApi.Orders.Api
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
            services.AddControllers()
                .AddJsonOptions(configure: options =>
                {
                    options.JsonSerializerOptions.Converters.Add(item: new UserNameJsonConverter());
                    options.JsonSerializerOptions.Converters.Add(item: new BudApiMetadataConverter());
                });

            services.AddDbContext<DemoContext>(optionsAction: optionsBuilder => optionsBuilder.UseSqlServer(connectionString: Configuration.GetConnectionString(name: "Demo")));
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

            app.UseEndpoints(configure: endpoints => { endpoints.MapControllers(); });
        }
    }
}