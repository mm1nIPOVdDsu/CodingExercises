namespace RickAndMorty.Data.Extensions
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    using RickAndMorty.Domain.Exceptions;

    /// <summary>
    ///     
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        ///     
        /// </summary>
        public static JsonSerializerOptions DefaultSerializerOptions => DefaultSerializerOptionsValue;
        /// <summary>
        ///     
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="throwOnFailure"></param>
        /// <returns></returns>
        public static T? FromJson<T>(this string value, JsonSerializerOptions? options = null, bool throwOnFailure = false)
            where T : class
        {
            T? result = default;

            if (!string.IsNullOrWhiteSpace(value))
            {
                try
                {
                    result = JsonSerializer.Deserialize<T>(value, options ?? DefaultSerializerOptions);
                }
                catch (Exception ex)
                {
                    if (throwOnFailure)
                    {
                        throw new JsonSerializationException($"Unable to deserialize item of type {typeof(T).Name} from provided value.", ex);
                    }
                }
            }

            return result;
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <param name="throwOnFailure"></param>
        /// <returns></returns>
        public static object? FromJson(this string value, Type type, JsonSerializerOptions? options = null, bool throwOnFailure = false)
        {
            object? result = null;

            if (!string.IsNullOrWhiteSpace(value))
            {
                try
                {
                    result = JsonSerializer.Deserialize(value, type, options ?? DefaultSerializerOptions);
                }
                catch (Exception ex)
                {
                    if (throwOnFailure)
                    {
                        throw new JsonSerializationException($"Unable to deserialize item of type {type.Name} from provided value.", ex);
                    }
                }
            }

            return result;
        }

#pragma warning disable S4225 // Extension methods should not extend "object"
        /// <summary>
        ///     
        /// </summary>
        /// <param name="item"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToJson(this object item, JsonSerializerOptions? options = null)
#pragma warning restore S4225 // Extension methods should not extend "object"
        {
            string result = string.Empty;

            if (item != null)
            {
                result = JsonSerializer.Serialize(item, options ?? DefaultSerializerOptions);
            }

            return result;
        }

#pragma warning disable S4225 // Extension methods should not extend "object"
        /// <summary>
        ///     
        /// </summary>
        /// <param name="item"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static string ToJson(this object item, Type type, JsonSerializerOptions? options = null)
#pragma warning restore S4225 // Extension methods should not extend "object"
        {
            string result = string.Empty;

            if (item != null)
            {
                result = JsonSerializer.Serialize(item, type, options ?? DefaultSerializerOptions);
            }

            return result;
        }

        /// <summary>
        ///     
        /// </summary>
        private static readonly JsonSerializerOptions DefaultSerializerOptionsValue = CreateDefaultJsonSerializerOptions();
        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        private static JsonSerializerOptions CreateDefaultJsonSerializerOptions()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IgnoreNullValues = false,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            options.Converters.Add(new JsonStringEnumConverter());

            return options;
        }
    }
}
