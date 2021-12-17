namespace RickAndMorty.Data.Entities
{
    using RickAndMorty.Data.Interfaces;

    /// <summary>
    ///     The base class for all entities.
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        /// <summary>
        ///     The entity's id.
        /// </summary>
        public int Id { get; set; }
    }
}
