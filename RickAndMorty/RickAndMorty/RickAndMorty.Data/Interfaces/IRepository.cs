using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using RickAndMorty.Data.Interfaces;

namespace RickAndMorty.Data
{
    /// <summary>
    ///     
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : IBaseEntity
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(long id);
        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        ///     
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<T> GetOneWhere(Expression<Func<T, bool>> where);
        /// <summary>
        ///     
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllWhere(Expression<Func<T, bool>> where);
    }
}
