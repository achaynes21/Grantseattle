using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IPropertyRegistration
    {
        Propertys GetById(string id);
        void Save(Propertys entity);
        void Delete(Propertys entity);
        IList<Propertys> GetList();
        void Edit(Propertys oldModelObj);
        //void SavePropertyPurpose(IList<Propertys> propertyPurposes);

        bool IsPropertyExits(string title, decimal price);



        Propertys GetIdenticalPropertyByTitleAndPriceAndEstablished(string title, decimal price);

        void UpdatePropertyAndPropertyImages(Propertys propertyGetFromDb, PropertyImages propertyImages);

        IList<Propertys> GetPropertyBySearchingCriter(string cityName, string location, string propType, string bed, string minPrice, string maxPrice, string generalSearch);

        IList<Propertys> GetPropertyBySearchingCriteriaAgent(string cityName, string location, string propType, string agentName, string generalSearch);
    }
}
