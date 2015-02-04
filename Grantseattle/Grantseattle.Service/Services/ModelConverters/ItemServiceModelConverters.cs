using InventoryERP.Domain;
using InventoryERP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services.ModelConverters
{
    public static class ItemServiceModelConverters
    {
        public static ItemListShortViewModel ToItemListShortViewModel(this Item source)
        {
            var target = new ItemListShortViewModel();

            target.Name = source.Name;
            target.BrandName = source.BrandName;
            target.ModelNo = source.ModelNo;
            target.Price = source.Price;
            target.CreatedAt = source.CreatedAt.ToString("MMM dd, yyyy");

            return target;
        }
    }
}
