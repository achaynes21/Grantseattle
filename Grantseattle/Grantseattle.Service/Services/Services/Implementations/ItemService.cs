using InventoryERP.Core;
using InventoryERP.Data;
using InventoryERP.Domain;
using InventoryERP.Services.Models;
using InventoryERP.Services.ModelConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services.Implementations
{
    public class ItemService : BaseService, IItemService
    {
        private IRepository<Item> ItemRepository { get; set; }

        public ItemService(IRepository<Item> itemRepository)
        {
            ItemRepository = itemRepository;
        }

        public Item GetItemById(string id)
        {
            return ItemRepository.GetById(id);
        }

        public void Save(Item entity)
        {
            ItemRepository.Save(entity);
        }

        public void Delete(Item entity)
        {
            entity.Deleted = true;
            entity.UpdatedAt = DateTime.UtcNow;

            ItemRepository.Save(entity);
        }

        public IList<Item> GetItemList()
        {
            return ItemRepository.GetQuery().Where(x => !x.Deleted).ToList();
        }

        public IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model)
        {
            var query = ItemRepository.GetQuery().Where(x => !x.Deleted);

            if(model.SearchString.IsNotNullOrWhiteSpace())
            {
                query = query.Where(x => x.Name.ToLower().Contains(model.SearchString.ToLower()) || x.BrandName.ToLower().Contains(model.SearchString.ToLower()));
            }

            //Implement sorting
            var total = query.Count();

            if(total <= model.PageSize)
                model.PageSize -= 1;

            var projectedQuery = query.Skip(model.PageSize * model.PageIndex).ToList();

            var items = projectedQuery.Select(x => x.ToItemListShortViewModel()).ToList();

            return new PagedList<ItemListShortViewModel>(items, model.PageIndex, model.PageSize, total);
        }
    }
}
