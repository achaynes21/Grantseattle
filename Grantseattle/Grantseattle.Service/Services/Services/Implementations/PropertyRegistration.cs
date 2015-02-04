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
    public class PropertyRegistration : BaseService, IPropertyRegistration
    {
        private IRepository<Propertys> PropertyRepository { get; set; }

        public PropertyRegistration(IRepository<Propertys> propertyRepository)
        {
            PropertyRepository = propertyRepository;
        }

        public Propertys GetById(string id)
        {
            return PropertyRepository.GetById(id);
        }

        public void Save(Propertys entity)
        {
            PropertyRepository.Save(entity);
        }

        public void Delete(Propertys entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            PropertyRepository.Save(entity);
        }

        public IList<Propertys> GetList()
        {
            return PropertyRepository.GetQuery().Where(x => x.Status == Propertys.PropertyStatusText.Active).ToList();
        }

        public void Edit(Propertys oldModelObj)
        {
            /*Have ti implement this */
            //NewsRepository.
        }

        public bool IsPropertyExits(string title, decimal price)
        {
            var ss = PropertyRepository.GetQuery().SingleOrDefault(x => x.Price == price && x.Name == title);
            if (ss != null)
            {
                return true;
            }
            return false;
        }

        public Propertys GetIdenticalPropertyByTitleAndPriceAndEstablished(string title, decimal price)
        {
            return PropertyRepository.GetQuery().SingleOrDefault(x => x.Name == title && x.Price == price);
        }

        public void UpdatePropertyAndPropertyImages(Propertys propertyGetFromDb, PropertyImages propertyImages)
        {
            propertyGetFromDb.PropertyImageses.Add(propertyImages);
            PropertyRepository.Save(propertyGetFromDb);
        }

        public IList<Propertys> GetPropertyBySearchingCriter(string cityName, string location, string propType, string bed, string minPrice,
            string maxPrice, string generalSearch)
        {
            IList<Propertys> result = PropertyRepository.GetPropertyBySearchingCriter(cityName, location, propType, bed,
                minPrice, maxPrice, generalSearch);
            return result;
           

        }

        public IList<Propertys> GetPropertyBySearchingCriteriaAgent(string cityName, string location, string propType, string agentName,
            string generalSearch)
        {
            IList<Propertys> result = PropertyRepository.GetPropertyBySearchingCriterAgent(cityName, location, propType, agentName, generalSearch);
            return result;
           
        }
    }
}
