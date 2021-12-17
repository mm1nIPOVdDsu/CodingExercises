using System;
using System.Collections.Generic;
using System.Linq;

using RickAndMorty.Data.Entities;
using RickAndMorty.Data.Interfaces;
using RickAndMorty.Domain.Interfaces;
using RickAndMorty.Domain.Models;
using RickAndMorty.Services.Interfaces;

namespace RickAndMorty.Services.Mappers
{
    /// <summary>
    ///     The base mapping service.
    /// </summary>
    /// <typeparam name="TModel"><see cref="BaseModel"/></typeparam>
    /// <typeparam name="TEntity"><see cref="BaseEntity"/></typeparam>
    public abstract class BaseMapper<TModel, TEntity> : IBaseMapper<TModel, TEntity>
        where TModel : class, IBaseModel, new()
        where TEntity : class, IBaseEntity, new()
    {
        /// <summary>
        ///     Maps from a <see cref="BaseModel"/> to a <see cref="BaseEntity"/>.
        /// </summary>
        /// <param name="model">The <see cref="BaseModel"/> to map from.</param>
        /// <returns>An instance of a <see cref="BaseEntity"/></returns>
        public virtual TEntity MapToEntity(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return Map<TEntity>(model);
        }
        /// <summary>
        ///     Maps from a <see cref="BaseModel"/> to a <see cref="BaseEntity"/>.
        /// </summary>
        /// <param name="model">The <see cref="BaseModel"/> to map from.</param>
        /// <returns>An instance of a <see cref="BaseEntity"/></returns>
        public virtual IEnumerable<TEntity> MapToEntity(IEnumerable<TModel> models)
        {
            if (models == null)
                throw new ArgumentNullException(nameof(models));

            var response = new List<TEntity>();
            foreach (var model in models)
                response.Add(Map<TEntity>(model));

            return response;
        }

        /// <summary>
        ///     Maps from a <see cref="BaseEntity"/> to a <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="entity">The <see cref="BaseEntity"/> to map from.</param>
        /// <returns>An instance of a <see cref="BaseModel"/></returns>
        public virtual TModel MapToModel(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return Map<TModel>(entity);
        }
        /// <summary>
        ///     Maps from a <see cref="BaseEntity"/> to a <see cref="BaseModel"/>.
        /// </summary>
        /// <param name="entity">The <see cref="BaseEntity"/> to map from.</param>
        /// <returns>An instance of a <see cref="BaseModel"/></returns>
        public virtual IEnumerable<TModel> MapToModel(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            var response = new List<TModel>();
            foreach (var entity in entities)
                response.Add(Map<TModel>(entity));

            return response;
        }

        /// <summary>
        ///     Sets the values of matching properties between two classes.
        /// </summary>
        /// <typeparam name="T">The object that is getting mapped to.</typeparam>
        /// <param name="item">The object that is getting mapped from.</param>
        /// <returns><typeparamref name="T"/></returns>
        private T Map<T>(object item)
        {
            var modelProperties = item.GetType().GetProperties();
            var entityProperties = typeof(T).GetProperties();
            var response = default(T);

            foreach (var modelProperty in modelProperties)
            {
                var entityProperty = entityProperties.FirstOrDefault(ep => ep.Name == modelProperty.Name && ep.PropertyType == modelProperty.PropertyType);
                if (entityProperty == null)
                    continue;

                entityProperty.SetValue(response, modelProperty.GetValue(item));
            }

            return response;
        }
    }
}
