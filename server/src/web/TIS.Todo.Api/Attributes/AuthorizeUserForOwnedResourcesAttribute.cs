using Microsoft.AspNetCore.Mvc;

namespace TIS.Todo.Api.Attributes
{
    /// <summary>
    ///     AuthorizeUserForOwnedResourcesAttribute
    /// </summary>
    public class AuthorizeUserForOwnedResourcesAttribute : TypeFilterAttribute
    {
        /// <summary>
        ///     AuthorizeUserForOwnedResourcesAttribute
        /// </summary>
        public AuthorizeUserForOwnedResourcesAttribute() : base(typeof(AuthorizeUserForOwnedResourcesFilter))
        {
        }
    }
}