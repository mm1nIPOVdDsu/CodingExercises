namespace RickAndMorty.Data.Interfaces
{
    /// <summary>
    ///     Represents a character's attributes.
    /// </summary>
    public interface ICharacterEntity
    {
        /// <summary>
        ///     The Character's catchphrase.
        /// </summary>
        string Catchphrase { get; }
        /// <summary>
        ///     The Character's name.
        /// </summary>
        string Name { get; }
    }
}
