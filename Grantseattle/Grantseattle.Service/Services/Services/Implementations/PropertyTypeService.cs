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
    public class PropertyTypeService:BaseService,IPropertyTypeService
    {
        private IRepository<PropertyType> propertyRepository { get; set; }

        public PropertyTypeService(IRepository<PropertyType> newsRepository)
        {
            propertyRepository = newsRepository;
        }

        public PropertyType GetById(string id)
        {
            return propertyRepository.GetById(id);
        }

        public void Save(PropertyType entity)
        {
            propertyRepository.Save(entity);
        }

        public void Delete(PropertyType entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            propertyRepository.Save(entity);
        }

        public IList<PropertyType> GetList()
        {
            return propertyRepository.GetQuery().Where(x => x.Status== Propertys.PropertyStatusText.Active).ToList();
        }

        public void Edit(PropertyType oldModelObj)
        {
            /*Have ti implement this */
            //NewsRepository.
        }

    }
}
