using InventoryERP.Services;
using InventoryERP.Web.Models;
using InventoryERP.Web.ModelConverters;
using InventoryERP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryERP.Domain;

namespace InventoryERP.Web.ModelBuilders
{
    public class ItemEditModelBuilder
    {
        public static void Save(IItemService itemService, ItemEditModel model, IAccountService accountService, string userId)
        {
            var user = accountService.GetUserById(userId);
            var item = model.Id.IsNotNullOrWhiteSpace() ? itemService.GetItemById(model.Id) : new Item();
            model.ToItem(item);

            if(model.Id.IsNullOrWhiteSpace())
            {
                item.CreatedAt = DateTime.UtcNow;
            }

            item.CreatedBy = user;
            item.UpdatedAt = DateTime.UtcNow;
            itemService.Save(item);
        }
    }

    public class ItemListViewModelBuilder
    {
        public static ItemListViewModel Build(ItemListViewModel model, IItemService itemService)
        {
            var criteriaModel = model.ToGeneralCriteriaModel();
            criteriaModel.PageSize = App.Configurations.ItemListSize.Value;

            model.Items = itemService.GetItemList(criteriaModel);

            return model;
        }
    }
}