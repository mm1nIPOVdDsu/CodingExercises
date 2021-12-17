namespace RickAndMorty.Domain.Interfaces
{
    /// <summary>
    ///     The base class for all models/entities.
    /// </summary>
    public interface IRoot
    {
        /// <summary>
        ///     The item's id.
        /// </summary>
        int Id { get; }
    }
}
