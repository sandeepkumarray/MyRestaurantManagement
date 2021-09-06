using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Helpers
{
    public class AuthorizeLoggedIn: IAuthorizationRequirement
    {
        public AuthorizeLoggedIn()
        {

        }
    }
    public class LoggedIn : AuthorizationHandler<AuthorizeLoggedIn>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        public LoggedIn(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       AuthorizeLoggedIn requirement)
        {

            var UserID = _session.GetString(AppConstants.JWTTOKEN);
            if (!string.IsNullOrEmpty(UserID))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
