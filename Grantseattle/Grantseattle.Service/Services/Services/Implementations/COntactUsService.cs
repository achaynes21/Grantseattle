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
    public class ContactUsService : BaseService, IContactUsService
    {
        private IRepository<ContactUs> ContactUSRepository { get; set; }

        public ContactUsService(IRepository<ContactUs> newsRepository)
        {
            ContactUSRepository = newsRepository;
        }

        public ContactUs GetAgentById(string id)
        {
            return ContactUSRepository.GetById(id);
        }

        public void Save(ContactUs entity)
        {
            ContactUSRepository.Save(entity);
        }

        public void Delete(ContactUs entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            ContactUSRepository.Save(entity);
        }

        public IList<ContactUs> GetAgentList()
        {
            return ContactUSRepository.GetQuery().Where(x => x.Status == Propertys.PropertyStatusText.Active).ToList();
        }

    }
}
