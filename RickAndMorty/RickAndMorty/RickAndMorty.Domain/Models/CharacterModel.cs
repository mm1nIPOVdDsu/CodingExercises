using RickAndMorty.Domain.Interfaces;

namespace RickAndMorty.Domain.Models
{
    /// <summary>
    ///     Represents a character's attributes.
    /// </summary>
    public class CharacterModel : BaseModel, ICharacterModel
    {
        /// <summary>
        ///     The Character's catchphrase.
        /// </summary>
        public string Catchphrase { get; set; }
        /// <summary>
        ///     The Character's name.
        /// </summary>
        public string Name { get; set; }
    }
}
