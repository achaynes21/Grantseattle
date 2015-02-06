using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryERP.Services;

namespace InventoryERP.Controllers
{
    public class AdminController : Controller
    {
        protected IAccountService AccountService { get; private set; }

        public AdminController(IAccountService accountService)
        {
            AccountService = accountService;
        }
        [Authorize]
        //[AuthorizeAccess]
        public virtual ActionResult Index()
        {
            var email = System.Web.HttpContext.Current.User.Identity.Name;
            var user = AccountService.GetUserByEmail(email);
            if (user.Role == "Admin")
            {
                return View();
            }
            return RedirectToAction("Index", "Client");
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
	}
}