using InventoryERP.Services;
using InventoryERP.Web.ModelBuilders;
using InventoryERP.Web.Models;
using InventoryERP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryERP.Web.Controllers
{
    [Authorize]
    public partial class ItemController : BaseMVCController
    {
        protected IItemService ItemService { get; private set; }
        protected IAccountService AccountService { get; private set; }

        public ItemController(IItemService itemService, IAccountService accountService)
        {
            ItemService = itemService;
            AccountService = accountService;
        }
        public virtual ActionResult CreateItem()
        {
            var model = new ItemEditModel();
            return View(model);
        }
        [HttpPost]
        public virtual ActionResult CreateItem(ItemEditModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = HttpContextHelper.Current.UserId;

            ItemEditModelBuilder.Save(ItemService, model, AccountService, userId);

            return RedirectToRoute(MVC.RouteNames.Item.ItemList);
        }

        public virtual ActionResult ViewItems(int? pageIndex, string sortBy, string sortOrder, string searchString)
        {
            pageIndex = pageIndex.HasValue ? pageIndex.Value : 0;
            sortBy = sortBy.IsNotNullOrWhiteSpace() ? sortBy : "Name";
            sortOrder = sortOrder.IsNotNullOrWhiteSpace() ? sortOrder : "Name";

            var model = new ItemListViewModel 
            {
                SearchString = searchString,
                SortBy = sortOrder,
                SortOrder = sortOrder,
                PageIndex = pageIndex.Value
            };

            ItemListViewModelBuilder.Build(model, ItemService);

            return RedirectToAction("CreateItem");
        }
	}
}