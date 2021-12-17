using System.Threading.Tasks;

using RickAndMorty.Data;
using RickAndMorty.Data.Entities;
using RickAndMorty.Domain.Interfaces;
using RickAndMorty.Domain.Models;
using RickAndMorty.Services.Interfaces;

namespace RickAndMorty.Services
{
    /// <summary>
    ///     
    /// </summary>
    public sealed class CharacterService : DataService<CharacterModel, CharacterEntity, ICharacterMapper, IRepository<CharacterEntity>>, ICharacterService
    {
        private readonly ILoggingService _loggingService;

        /// <summary>
        ///     
        /// </summary>
        /// <param name="loggingService"></param>
        /// <param name="repository"></param>
        /// <param name="characterMapper"></param>
        public CharacterService(ILoggingService loggingService, IRepository<CharacterEntity> repository, ICharacterMapper characterMapper) : base(repository, characterMapper)
        {
            _loggingService = loggingService;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        public async Task<ICharacterModel> SomeSpecificMethod()
        {
            var entity = await Repository.GetById(1);
            return Mapper.MapToModel(entity);
        }
    }
}
