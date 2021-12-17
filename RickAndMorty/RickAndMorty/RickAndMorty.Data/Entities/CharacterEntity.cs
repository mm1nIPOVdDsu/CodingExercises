using RickAndMorty.Data.Interfaces;

namespace RickAndMorty.Data.Entities
{
    /// <summary>
    ///     Represents a character's attributes.
    /// </summary>
    public class CharacterEntity : BaseEntity, ICharacterEntity
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
