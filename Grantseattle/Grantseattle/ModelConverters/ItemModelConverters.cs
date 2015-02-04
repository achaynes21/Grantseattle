using InventoryERP.Domain;
using InventoryERP.Services.Models;
using InventoryERP.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryERP.Web.ModelConverters
{
    public static class ItemModelConverters
    {
        public static Item ToItem(this ItemEditModel source, Item target)
        {
            target.Id = source.Id;
            target.Name = source.Name;
            target.BrandName = source.BrandName;
            target.ModelNo = source.ModelNo;
            target.Price = source.Price;

            return target;
        }

        public static ItemEditModel ToItemEditModel(this Item source)
        {
            var target = new ItemEditModel();

            target.Id = source.Id;
            target.Name = source.Name;
            target.BrandName = source.BrandName;
            target.ModelNo = source.ModelNo;
            target.Price = source.Price;

            return target;
        }

        public static GeneralCriteriaModel ToGeneralCriteriaModel(this ItemListViewModel source)
        {
            var target = new GeneralCriteriaModel();

            target.PageIndex = source.PageIndex;
            target.SearchString = source.SearchString;
            target.SortBy = source.SortBy;
            target.SortOrder = source.SortOrder;

            return target;
        }
    }
}