using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RickAndMorty.Data.Entities;
using RickAndMorty.Data.Extensions;
using RickAndMorty.Data.Interfaces;
using RickAndMorty.Domain.Attributes;
using RickAndMorty.Domain.Enums;

namespace RickAndMorty.Data
{
    /// <summary>
    ///     
    /// </summary>
    [Strategy(LoadStrategy.Singleton)]
    public class RmDbContext : IRmDbContext
    {
        /// <summary>
        ///     
        /// </summary>
        public IEnumerable<CharacterEntity> Characters { get; set; }

        /// <summary>
        ///     
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> Set<TEntity>() where TEntity : class, IBaseEntity
        {
            var toSet = this.GetType().GetProperties().FirstOrDefault(p => p.PropertyType.GetGenericArguments().FirstOrDefault() == typeof(TEntity));
            if (toSet == null)
                throw new Exception("TODO");

            var propertyValue = toSet.GetValue(this);
            await Task.Delay(0);

            if (propertyValue == null)
            {
                var entityType = toSet.PropertyType.GetGenericArguments().FirstOrDefault();
                propertyValue = await $"{entityType.Name}.json".GetJsonFromManifestResource<IEnumerable<TEntity>>(typeof(RmDbContext));
                if (propertyValue == null)
                    throw new Exception("TODO");

                toSet.SetValue(this, propertyValue);
            }

            return (IEnumerable<TEntity>)propertyValue;
        }
    }
}
