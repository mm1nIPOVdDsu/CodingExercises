namespace RickAndMorty.Domain
{
    /// <summary>
    ///     
    /// </summary>
    public sealed class Character
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="catchphrase"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Character(
            string catchphrase,
            int id,
            string name)
        {
            this.Catchphrase = catchphrase;
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        ///     
        /// </summary>
        public string Catchphrase { get; }
        /// <summary>
        ///     
        /// </summary>
        public int Id { get; }
        /// <summary>
        ///     
        /// </summary>
        public string Name { get; }
    }
}