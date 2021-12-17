namespace RickAndMorty
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using RickAndMorty.Bootstrap;
    using RickAndMorty.Configuration;

    /// <summary>
    ///     
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="environment"></param>
        public Startup(IWebHostEnvironment environment)
        {
            this.Configuration = environment.CreateConfiguration();
        }

        /// <summary>
        ///     
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<KestrelServerOptions>(options => { });
            services.Configure<IISServerOptions>(options => { });

            Bootstrapper.BuildContainer(services);

            services.AddApiVersioning();
            services.ConfigureSwagger("v1", "RickAndMorty");
            services.AddControllers(o => { });
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="application"></param>
        /// <param name="environment"></param>
        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                // enables the ability retry requests on exception.
                application.UseExceptionHandler();
            }

            application.UseSwagger(
                routePrefix: string.Empty,
                serviceName: "RickAndMorty",
                schemeAndDomain: "http://localhost:8962");
            application.UseRouting();
            application.UseEndpoints(c => { c.MapControllers(); });
        }
    }
}