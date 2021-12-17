using System.Threading.Tasks;

using RickAndMorty.Domain.Interfaces;
using RickAndMorty.Domain.Models;

namespace RickAndMorty.Services.Interfaces
{
    /// <summary>
    ///     
    /// </summary>
    public interface ICharacterService : IDataService<CharacterModel> //IDataService<CharacterModel, CharacterEntity, CharacterMapper>
    {
        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        Task<ICharacterModel> SomeSpecificMethod();
    }
}
