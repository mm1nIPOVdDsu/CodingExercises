using System.Collections.Generic;
using System.Threading.Tasks;

using RickAndMorty.Data.Interfaces;

namespace RickAndMorty.Data
{
    /// <summary>
    ///     
    /// </summary>
    public interface IRmDbContext
    {
        /// <summary>
        ///     
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> Set<TEntity>() where TEntity : class, IBaseEntity;
    }
}
