using InventoryERP.Core;
using InventoryERP.Domain;
using InventoryERP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services
{
    public interface IItemService
    {
        Item GetItemById(string id);
        void Save(Item entity);
        void Delete(Item entity);
        IList<Item> GetItemList();
        IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model);
    }
}
