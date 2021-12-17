using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using RickAndMorty.Data.Interfaces;

namespace RickAndMorty.Data
{
    /// <summary>
    ///     
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly IRmDbContext _rmDbContext;

        public Repository(IRmDbContext RmDbContext)
        {
            _rmDbContext = RmDbContext;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetById(long id)
        {
            return (await this.GetAll()).FirstOrDefault(n => n.Id == id);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _rmDbContext.Set<T>();
        }

        #region Expressions
        /// <summary>
        ///     
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<T> GetOneWhere(Expression<Func<T, bool>> where)
        {
            if (where == null)
                throw new ArgumentNullException();

            return (await GetAll()).AsQueryable().FirstOrDefault(where);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<T>> GetAllWhere(Expression<Func<T, bool>> where)
        {
            if (where == null)
                throw new ArgumentNullException();

            return (await GetAll()).AsQueryable().Where(where);
        }
        #endregion
    }
}
