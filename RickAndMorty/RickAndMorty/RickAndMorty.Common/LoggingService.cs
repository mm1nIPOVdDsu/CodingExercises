using System;
using System.Threading.Tasks;

using RickAndMorty.Domain.Attributes;
using RickAndMorty.Domain.Enums;
using RickAndMorty.Domain.Interfaces;

namespace RickAndMorty.Common
{
    /// <summary>
    ///     
    /// </summary>
    [Strategy(LoadStrategy.Singleton)]
    public class LoggingService : ILoggingService
    {
        /// <summary>
        ///     
        /// </summary>
        public LoggingService()
        {
            // read log level from some place and set it.
            this.LoggingLevel = LoggingLevel.Info;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Debug(string message) => await Log(message);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Error(string message) => await Log(message);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public async Task Error(Exception ex) => await Log(ex.Message);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Info(string message) => await Log(message);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task Warn(string message) => await Log(message);

        /// <summary>
        ///     
        /// </summary>
        public LoggingLevel LoggingLevel { get; }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task Log(string message)
        {
            await Task.Factory.StartNew(() =>
            {
                Console.WriteLine(message);
            });
        }
    }
}
