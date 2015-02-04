using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using InventoryERP.Data;
using InventoryERP.Domain;
using InventoryERP.Services;
using InventoryERP.Services.Implementations;
using Microsoft.AspNet.Identity;

namespace InventoryERP.App_Start
{
    public class AuthorizeAccess : ActionFilterAttribute
    {
        protected IAccountService AccountService { get;  private set; }
        public IRepository<Member> MemberRepository { get;  set; }
        public AuthorizeAccess()
        {
            //IRepository<Member> MemberRepository=null;
            AccountService = new AccountService(MemberRepository);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var email = HttpContext.Current.User.Identity.Name;
            var user = AccountService.GetUserByEmail(email);
            if (user.Role.Equals("Admin"))
            {
                RedirectToLogin(filterContext);
            }
            else if (user.Role.Equals("Member"))
            {
                RedirectToLogin(filterContext);
            }
        }
        private void RedirectToLogin(ActionExecutingContext filterContext)
        {
            var rvd = new RouteValueDictionary();
            rvd.Add("message", "Permission Denied. User appropiate login");
            filterContext.Result = new RedirectToRouteResult("Login", rvd);
        }
    }
}