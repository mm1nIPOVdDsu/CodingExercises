using System.Collections.Generic;

using RickAndMorty.Data.Entities;
using RickAndMorty.Domain.Models;
using RickAndMorty.Services.Interfaces;

namespace RickAndMorty.Services.Mappers
{
    /// <summary>
    ///     Maps a CharacterModel to and from a CharacterEntity.
    /// </summary>
    public class CharacterMapper : BaseMapper<CharacterModel, CharacterEntity>, ICharacterMapper
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override CharacterEntity MapToEntity(CharacterModel model)
        {
            return new CharacterEntity()
            {
                Catchphrase = model.Catchphrase,
                Id = model.Id,
                Name = model.Name
            };
        }
        /// <summary>
        ///     `
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public override IEnumerable<CharacterEntity> MapToEntity(IEnumerable<CharacterModel> models)
        {
            var response = new List<CharacterEntity>();
            foreach (var model in models)
                response.Add(MapToEntity(model));

            return response;

        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override CharacterModel MapToModel(CharacterEntity entity)
        {
            return new CharacterModel()
            {
                Catchphrase = entity.Catchphrase,
                Id = entity.Id,
                Name = entity.Name
            };
        }
        /// <summary>
        ///     `
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public override IEnumerable<CharacterModel> MapToModel(IEnumerable<CharacterEntity> entities)
        {
            var response = new List<CharacterModel>();
            foreach (var entity in entities)
                response.Add(MapToModel(entity));

            return response;

        }
    }
}
