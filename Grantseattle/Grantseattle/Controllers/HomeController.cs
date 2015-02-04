using InventoryERP.App_Start;
using InventoryERP.Services;
using InventoryERP.Services.Implementations;
using InventoryERP.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryERP.Controllers
{
    public partial class HomeController : BaseMVCController
    {
        protected IAccountService AccountService { get; private set; }

        public HomeController(IAccountService accountService)
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