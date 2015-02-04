using System;
using InventoryERP.Core;
using InventoryERP.Domain;
using InventoryERP.Services;
using InventoryERP.Web.ModelConverters;
using InventoryERP.Web.Models;

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