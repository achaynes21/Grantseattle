using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryERP.Core;
using InventoryERP.ModelConverters;
using InventoryERP.Models;
using InventoryERP.Service.Services.Services;
using InventoryERP.Services;
using InvertoryERP.Core.Domain;

namespace InventoryERP.ModelBuilders
{
    public class NewsEditModelBuilder
    {
        public static void Save(INewsPortalService newsPortalService,
            EditNewsPortal model, IAccountService accountService, string userId)
        {
            var user = accountService.GetUserById(userId);
            var item = model.Id.IsNotNullOrWhiteSpace() ? newsPortalService.GetNewsById(model.Id) : new News();
            model.ToNews(item);

            if(model.Id.IsNullOrWhiteSpace())
            {
                item.CreatedAt = DateTime.UtcNow;
            }
            item.CreatedBy = user;
            item.UpdatedAt = DateTime.UtcNow;
            item.Status = Propertys.PropertyStatusText.Active;
            item.IsDelete = false;
            item.Member = user;
            newsPortalService.Save(item);
        }
    }
}