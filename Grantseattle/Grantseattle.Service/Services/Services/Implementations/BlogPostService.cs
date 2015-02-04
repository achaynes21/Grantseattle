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
    public class BlogPostService : BaseService, IBlogPostService
    {
        private IRepository<BlogContent> bolgPostRepository { get; set; }

        public BlogPostService(IRepository<BlogContent> newsRepository)
        {
            bolgPostRepository = newsRepository;
        }

        public BlogContent GetById(string id)
        {
            return bolgPostRepository.GetById(id);
        }

        public void Save(BlogContent entity)
        {
            bolgPostRepository.Save(entity);
        }

        public void Delete(BlogContent entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            bolgPostRepository.Save(entity);
        }

        public IList<BlogContent> GetList()
        {
            return bolgPostRepository.GetQuery().
                Where(x => x.Status == Propertys.PropertyStatusText.Active).OrderByDescending(x => x.CreatedAt).ToList();
        }

        public void Edit(BlogContent oldModelObj)
        {
            throw new NotImplementedException();
        }
    }
}
