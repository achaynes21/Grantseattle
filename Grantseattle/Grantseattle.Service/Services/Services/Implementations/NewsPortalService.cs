using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Data;
using InventoryERP.Services;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services.Implementations
{
    public class NewsPortalService:BaseService,INewsPortalService
    {
        private IRepository<News> NewsRepository { get; set; }

        public NewsPortalService(IRepository<News> newsRepository)
        {
            NewsRepository = newsRepository;
        }

        public News GetNewsById(string id)
        {
            return NewsRepository.GetById(id);
        }

       public void Save(News entity)
        {
            NewsRepository.Save(entity);
        }

        public void Delete(News entity)
        {
            entity.IsDelete = true;
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            NewsRepository.Save(entity);
        }

        public IList<News> GetNewsList()
        {
            return NewsRepository.GetQuery().Where(x => !x.IsDelete && x.Status ==Propertys.PropertyStatusText.Active)
                .OrderByDescending(x=> x.CreatedAt).ToList();
        }

        public void Edit(News oldModelObj)
        {
            /*Have ti implement this */
            //NewsRepository.
        }

        //public IList<News> GetItemList()
        //{
        //    return NewsRepository.GetQuery().Where(x => !x.).ToList();
        //}

        //public IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model)
        //{
        //    var query = ItemRepository.GetQuery().Where(x => !x.Deleted);

        //    if(model.SearchString.IsNotNullOrWhiteSpace())
        //    {
        //        query = query.Where(x => x.Name.ToLower().Contains(model.SearchString.ToLower()) || x.BrandName.ToLower().Contains(model.SearchString.ToLower()));
        //    }

        //    //Implement sorting
        //    var total = query.Count();

        //    if(total <= model.PageSize)
        //        model.PageSize -= 1;

        //    var projectedQuery = query.Skip(model.PageSize * model.PageIndex).ToList();

        //    var items = projectedQuery.Select(x => x.ToItemListShortViewModel()).ToList();

        //    return new PagedList<ItemListShortViewModel>(items, model.PageIndex, model.PageSize, total);
        //}
    }
}
