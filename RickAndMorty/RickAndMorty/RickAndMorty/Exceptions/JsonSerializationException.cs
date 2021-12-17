namespace RickAndMorty.Exceptions
{
    using System;

    /// <summary>
    ///     
    /// </summary>
    public class JsonSerializationException : Exception
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        public JsonSerializationException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public JsonSerializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}