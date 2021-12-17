using System;

using RickAndMorty.Domain.Enums;

namespace RickAndMorty.Domain.Attributes
{
    /// <summary>
    ///     
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class StrategyAttribute : Attribute
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="strategy"></param>
        public StrategyAttribute(LoadStrategy strategy)
        {
            this.LoadStrategy = strategy;
        }

        /// <summary>
        ///     
        /// </summary>
        public LoadStrategy LoadStrategy { get; }
    }
}
