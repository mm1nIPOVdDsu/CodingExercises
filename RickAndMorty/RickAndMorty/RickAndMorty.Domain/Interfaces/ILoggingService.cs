using System;
using System.Threading.Tasks;

using RickAndMorty.Data.Interfaces;
using RickAndMorty.Domain.Enums;

namespace RickAndMorty.Domain.Interfaces
{
    /// <summary>
    ///     
    /// </summary>
    public interface ILoggingService : IBaseService
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Debug(string message);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Info(string message);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Warn(string message);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        Task Error(string message);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        Task Error(Exception ex);

        /// <summary>
        ///     
        /// </summary>
        LoggingLevel LoggingLevel { get; }
    }
}
