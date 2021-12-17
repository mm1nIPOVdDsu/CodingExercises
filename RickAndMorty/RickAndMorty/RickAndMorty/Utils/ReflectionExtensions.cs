//namespace RickAndMorty.Utils
//{
//    using System;
//    using System.IO;
//    using System.Threading.Tasks;

//    public static class ReflectionExtensions
//    {
//        /// <summary>
//        ///     
//        /// </summary>
//        /// <typeparam name="T"></typeparam>
//        /// <param name="resourceName"></param>
//        /// <param name="anyTypeFromResourceAssembly"></param>
//        /// <returns></returns>
//        public static async Task<T?> GetJsonFromManifestResource<T>(this string resourceName, Type anyTypeFromResourceAssembly)
//            where T : class
//        {
//            var json = await anyTypeFromResourceAssembly.GetManifestResourceString(resourceName);
//            return json.FromJson<T>(throwOnFailure: true);
//        }

//        /// <summary>
//        ///     
//        /// </summary>
//        /// <param name="type"></param>
//        /// <param name="name"></param>
//        /// <returns></returns>
//        public static async Task<string> GetManifestResourceString(this Type type, string name)
//        {
//            await using Stream? stream = type.Assembly.GetManifestResourceStream(type, name);

//            if (stream != null)
//            {
//                return await stream.ReadStringAsync() ?? string.Empty;
//            }

//            return string.Empty;
//        }
//    }
//}