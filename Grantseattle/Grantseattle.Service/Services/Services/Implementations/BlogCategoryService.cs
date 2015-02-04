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
    public class BlogCategoryService:BaseService,IBlogCategoryService
    {
        private IRepository<BlogCategory> BolgRepository { get; set; }

        public BlogCategoryService(IRepository<BlogCategory> newsRepository)
        {
            BolgRepository = newsRepository;
        }

        public BlogCategory GetById(string id)
        {
            return BolgRepository.GetById(id);
        }

        public void Save(BlogCategory entity)
        {
            BolgRepository.Save(entity);
        }

        public void Delete(BlogCategory entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            BolgRepository.Save(entity);
        }

        public IList<BlogCategory> GetList()
        {
            return BolgRepository.GetQuery().Where(x => x.Status == Propertys.PropertyStatusText.Active).ToList();
        }

        public void Edit(BlogCategory oldModelObj)
        {
            throw new NotImplementedException();
        }

    }
}
