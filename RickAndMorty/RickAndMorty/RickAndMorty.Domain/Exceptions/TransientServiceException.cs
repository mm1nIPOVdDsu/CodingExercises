namespace RickAndMorty.Domain.Exceptions
{
    using System;

    public sealed class TransientServiceException : Exception
    {
        public TransientServiceException(string message)
            : base(message)
        {
        }
    }
}
