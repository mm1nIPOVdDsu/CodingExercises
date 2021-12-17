using System.Collections.Generic;
using System.Threading.Tasks;

using RickAndMorty.Data;
using RickAndMorty.Data.Interfaces;
using RickAndMorty.Domain.Interfaces;
using RickAndMorty.Services.Interfaces;

namespace RickAndMorty.Services
{
    /// <summary>
    ///     
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TMapper"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public abstract class DataService<TModel, TEntity, TMapper, TRepository> : IDataService<TModel>
        where TModel : class, IBaseModel, new()
        where TEntity : class, IBaseEntity, new()
        where TMapper : class, IBaseMapper<TModel, TEntity>
        where TRepository : class, IRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly TMapper _mapper;

        /// <summary>
        ///     
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        protected DataService(
            TRepository repository,
            TMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        ///     
        /// </summary>
        protected TRepository Repository { get { return _repository; } }
        /// <summary>
        ///     
        /// </summary>
        protected TMapper Mapper { get { return _mapper; } }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await this.Repository.GetAll();
            return this.Mapper.MapToModel(entities);
        }
        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<TModel> GetByIdAsync(long id)
        {
            var entity = await this.Repository.GetById(id);
            if (entity == null)
                return null;

            return this.Mapper.MapToModel(entity);
        }
    }
}
