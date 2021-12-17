namespace RickAndMorty.Domain.Interfaces
{
    /// <summary>
    ///     The base class for all models.
    /// </summary>
    public interface IBaseModel : IRoot
    {
        /// <summary>
        ///     The model's id.
        /// </summary>
        int Id { get; }
    }
}
