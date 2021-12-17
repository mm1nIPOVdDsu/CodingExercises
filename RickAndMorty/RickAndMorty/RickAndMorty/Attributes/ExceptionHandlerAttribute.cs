namespace RickAndMorty.Attributes
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    ///     Attribute for handlinig WebAPI exceptions.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        ///     Logs exceptions that occur within web api controller methods.
        /// </summary>
        /// <param name="context"><see cref="ExceptionContext"/></param>
        /// <returns><see cref="Task"/></returns>
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            // TODO: add logging
            await base.OnExceptionAsync(context);
        }
    }
}
