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
    public class PropertyLocationService : BaseService, IPropertyLocationService
    {
        private IRepository<PropertyLocationType> propertyLocatioRepository { get; set; }

        public PropertyLocationService(IRepository<PropertyLocationType> newsRepository)
        {
            propertyLocatioRepository = newsRepository;
        }

        public PropertyLocationType GetById(string id)
        {
            return propertyLocatioRepository.GetById(id);
        }

        public void Save(PropertyLocationType entity)
        {
            propertyLocatioRepository.Save(entity);
        }

        public void Delete(PropertyLocationType entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            propertyLocatioRepository.Save(entity);
        }

        public IList<PropertyLocationType> GetList()
        {
            return propertyLocatioRepository.GetQuery().Where(x => x.Status == Propertys.PropertyStatusText.Active).ToList();
        }

        public void Edit(PropertyLocationType oldModelObj)
        {
            throw new NotImplementedException();
        }

        public void SavePropertyLocation(IList<PropertyLocationType> locationTypes)
        {
            propertyLocatioRepository.AddRange(locationTypes);
        }
    }
}
