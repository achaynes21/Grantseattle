using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Core;
using InventoryERP.Data;
using InventoryERP.Services;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services.Implementations
{
    public class PropertyPurposeService : BaseService, IPropertyPurposeService
    {
        private IRepository<PropertyPurpose> NewsRepository { get; set; }

        public PropertyPurposeService(IRepository<PropertyPurpose> newsRepository)
        {
            NewsRepository = newsRepository;
        }

        public PropertyPurpose GetById(string id)
        {
            return NewsRepository.GetById(id);
        }

       public void Save(PropertyPurpose entity)
        {
            NewsRepository.Save(entity);
        }

        public void Delete(PropertyPurpose entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            NewsRepository.Save(entity);
        }

        public IList<PropertyPurpose> GetList()
        {
            return NewsRepository.GetQuery().Where(x => x.Status == Propertys.PropertyStatusText.Active).ToList();
        }

        public void Edit(PropertyPurpose oldModelObj)
        {
            throw new NotImplementedException();
        }

        public void SavePropertyPurpose(IList<PropertyPurpose> propertyPurposes)
        {
            //Check.Argument.Null(entities, "entities");
            NewsRepository.AddRange(propertyPurposes);
            
        }
    }
}
