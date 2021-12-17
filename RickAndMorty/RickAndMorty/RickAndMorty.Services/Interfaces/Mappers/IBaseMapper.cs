using System.Collections.Generic;

using RickAndMorty.Data.Entities;
using RickAndMorty.Data.Interfaces;
using RickAndMorty.Domain.Interfaces;
using RickAndMorty.Domain.Models;

namespace RickAndMorty.Services.Interfaces
{
    /// <summary>
    ///     The base mapping service.
    /// </summary>
    /// <typeparam name="TModel"><see cref="BaseModel"/></typeparam>
    /// <typeparam name="TEntity"><see cref="BaseEntity"/></typeparam>
    public interface IBaseMapper<TModel, TEntity>
        where TModel : class, IBaseModel, new()
        where TEntity : class, IBaseEntity, new()
    {
        /// <summary>
        ///     Maps from a <see cref="BaseEntity"/> to a <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="entity">The <see cref="BaseEntity"/> to map from.</param>
        /// <returns>An instance of a <see cref="BaseModel"/></returns>
        TModel MapToModel(TEntity entity);
        /// <summary>
        ///     Maps from a <see cref="BaseEntity"/> to a <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="entity">The <see cref="BaseEntity"/> to map from.</param>
        /// <returns>An instance of a <see cref="BaseModel"/></returns>
        IEnumerable<TModel> MapToModel(IEnumerable<TEntity> entities);

        /// <summary>
        ///     Maps from a <see cref="BaseModel"/> to a <see cref="BaseEntity"/>.
        /// </summary>
        /// <param name="model">The <see cref="BaseModel"/> to map from.</param>
        /// <returns>An instance of a <see cref="BaseEntity"/></returns>
        TEntity MapToEntity(TModel model);
        /// <summary>
        ///     Maps from a <see cref="BaseModel"/> to a <see cref="BaseEntity"/>.
        /// </summary>
        /// <param name="model">The <see cref="BaseModel"/> to map from.</param>
        /// <returns>An instance of a <see cref="BaseEntity"/></returns>
        IEnumerable<TEntity> MapToEntity(IEnumerable<TModel> model);
    }
}
