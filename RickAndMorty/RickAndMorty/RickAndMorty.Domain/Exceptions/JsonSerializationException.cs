﻿using System;

namespace RickAndMorty.Domain.Exceptions
{
    public class JsonSerializationException : Exception
    {
        public JsonSerializationException(string message)
            : base(message)
        {
        }

        public JsonSerializationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
