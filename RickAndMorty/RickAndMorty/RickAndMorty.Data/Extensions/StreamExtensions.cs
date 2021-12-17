using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMorty.Data.Extensions
{
    /// <summary>
    ///     
    /// </summary>
    internal static class StreamExtensions
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string ReadString(this Stream stream)
        {
            using StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 4096);
            return reader.ReadToEnd();
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static Task<string> ReadStringAsync(this Stream stream)
        {
            using StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 4096);
            return reader.ReadToEndAsync();
        }
    }
}
