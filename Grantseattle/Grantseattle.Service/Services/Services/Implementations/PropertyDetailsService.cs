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
    public class PropertyDetailsService:BaseService,IPropertyDeteilsSevice
    {
        private IRepository<PropertyDetails> propertyDetailsRepository { get; set; }

        public PropertyDetailsService(IRepository<PropertyDetails> newsRepository)
        {
            propertyDetailsRepository = newsRepository;
        }

        public PropertyDetails GetById(string id)
        {
            return propertyDetailsRepository.GetById(id);
        }

        public void Save(PropertyDetails entity)
        {
            propertyDetailsRepository.Save(entity);
        }

        public void Delete(PropertyDetails entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            propertyDetailsRepository.Save(entity);
        }

        public IList<PropertyDetails> GetList()
        {
            return propertyDetailsRepository.GetQuery().Where(x => x.Status== Propertys.PropertyStatusText.Active).ToList();
        }

        public void Edit(PropertyDetails oldModelObj)
        {
            /*Have ti implement this */
            //NewsRepository.
        }
    }
}
