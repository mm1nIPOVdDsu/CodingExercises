using System.Collections.Generic;
using System.Threading.Tasks;

using RickAndMorty.Domain.Interfaces;

namespace RickAndMorty.Services.Interfaces
{
    /// <summary>
    ///     
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface IDataService<TModel> where TModel : class, IBaseModel
    {
        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TModel>> GetAllAsync();
        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TModel> GetByIdAsync(long id);
    }
}
