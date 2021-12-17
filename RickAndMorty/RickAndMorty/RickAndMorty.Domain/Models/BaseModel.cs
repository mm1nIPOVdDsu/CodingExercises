
using RickAndMorty.Domain.Interfaces;

namespace RickAndMorty.Domain.Models
{
    /// <summary>
    ///     The base class for all models.
    /// </summary>
    public abstract class BaseModel : IBaseModel
    {
        /// <summary>
        ///     The model's id.
        /// </summary>
        public int Id { get; set; }
    }
}
