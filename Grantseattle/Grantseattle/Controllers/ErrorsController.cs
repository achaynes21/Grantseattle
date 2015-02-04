using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryERP.Web.Controllers
{
    public partial class ErrorsController : BaseMVCController
    {
        public virtual ActionResult Index(string error)
        {
            ViewBag.Title = "We're Sorry.";

            return View();
        }

        public virtual ActionResult Http404(string error)
        {
            ViewBag.Title = "We're Sorry.";

            return View();
        }

        public virtual ActionResult Http404ForSubscription(string error)
        {
            ViewBag.Title = "We're Sorry.";

            return View();
        }

        public virtual ActionResult Http500(string error, string errorCode)
        {
            ViewBag.Title = "We're Sorry.";

            if (!string.IsNullOrEmpty(errorCode)) ViewData["ErrorCode"] = errorCode;

            return View();
        }
    }
}
