using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TIS.Todo.Api.Attributes
{
    /// <summary>
    ///     AuthorizeUserForOwnedResourcesFilter
    /// </summary>
    public class AuthorizeUserForOwnedResourcesFilter : IAuthorizationFilter
    {
        /// <summary>
        ///     OnAuthorizationAsync
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var queryUserId = context.RouteData.Values["user-id"]?.ToString();
            var identityUserId = context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(identityUserId) || !string.IsNullOrEmpty(queryUserId) &&
                !string.IsNullOrEmpty(identityUserId) && queryUserId.ToLower() != identityUserId.ToLower())
                context.Result = new ForbidResult(JwtBearerDefaults.AuthenticationScheme);
        }
    }
}