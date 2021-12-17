namespace RickAndMorty.Exceptions
{
    using System;

    /// <summary>
    ///     
    /// </summary>
    public sealed class TransientServiceException : Exception
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        public TransientServiceException(string message)
            : base(message)
        {
        }
    }
}