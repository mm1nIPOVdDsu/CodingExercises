namespace RickAndMorty.Configuration
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    ///     Extension methods for interacting with configuration files.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        ///     Creates a new configuration.
        /// </summary>
        /// <param name="environment"><see cref="IWebHostEnvironment"/></param>
        /// <returns><see cref="IConfiguration"/></returns>
        public static IConfiguration CreateConfiguration(this IWebHostEnvironment environment)
        {
            return environment.ContentRootPath
                .CreateConfiguration(environment.EnvironmentName)
                .Build();
        }

        /// <summary>
        ///     Creates a new configuration.
        /// </summary>
        /// <param name="applicationDirectory">The directory to create the confuguration.</param>
        /// <param name="environmentName">The name of the environment.</param>
        /// <returns><see cref="IConfigurationBuilder"/></returns>
        private static IConfigurationBuilder CreateConfiguration(
            this string applicationDirectory,
            string environmentName)
        {
            return new ConfigurationBuilder()
                .SetBasePath(applicationDirectory)
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentJson(environmentName)
                .AddEnvironmentVariables();
        }

        private static IConfigurationBuilder AddEnvironmentJson(
            this IConfigurationBuilder configurationBuilder,
            string environmentName)
        {
            IConfigurationBuilder result = configurationBuilder;

            environmentName = environmentName?.Trim() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(environmentName))
            {
                result = result.AddJsonFile($"appsettings.{environmentName}.json", true);
            }

            return result;
        }
    }
}