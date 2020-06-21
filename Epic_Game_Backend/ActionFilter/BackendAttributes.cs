using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Epic_Game_Backend.ActionFilter
{
    public class BackendAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException();

            //有設置AllowAnonymouse則不需要驗證
            if (SkipAuthorization(filterContext))
                return;

            var user = filterContext.RequestContext.HttpContext.User;
            var userIdentity = user.Identity;

            if (!userIdentity.IsAuthenticated)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));
                return;
            }

            if (!user.IsInRole("Admin"))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "MemberLogOff" }));
                return;
            }
        }

        private static bool SkipAuthorization(AuthorizationContext filterContext)
        {
            return filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) ||
            filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true);
        }
    }
}