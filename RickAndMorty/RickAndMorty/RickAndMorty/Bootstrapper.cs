namespace RickAndMorty.Bootstrap
{
    using Microsoft.Extensions.DependencyInjection;

    using RickAndMorty.Common;
    using RickAndMorty.Data;
    using RickAndMorty.Data.Entities;
    using RickAndMorty.Domain.Interfaces;
    using RickAndMorty.Services;
    using RickAndMorty.Services.Interfaces;
    using RickAndMorty.Services.Mappers;

    /// <summary>
    ///     Setup for the application.
    /// </summary>
    internal static class Bootstrapper
    {
        /// <summary>
        ///     Builds the IoC container.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        public static void BuildContainer(IServiceCollection services)
        {
            // register singletons
            // TODO: Use reflection to dynamically add container items.
            services.Add(new ServiceDescriptor(typeof(ILoggingService), typeof(LoggingService), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(ICharacterService), typeof(CharacterService), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IRepository<CharacterEntity>), typeof(Repository<CharacterEntity>), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(ICharacterMapper), typeof(CharacterMapper), ServiceLifetime.Singleton));
            services.Add(new ServiceDescriptor(typeof(IRmDbContext), typeof(RmDbContext), ServiceLifetime.Singleton));
        }
    }
}
