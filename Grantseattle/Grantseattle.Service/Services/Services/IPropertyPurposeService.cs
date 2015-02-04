using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IPropertyPurposeService
    {
        PropertyPurpose GetById(string id);
        void Save(PropertyPurpose entity);
        void Delete(PropertyPurpose entity);
        IList<PropertyPurpose> GetList();
        //IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model);

        void Edit(PropertyPurpose oldModelObj);

        void SavePropertyPurpose(IList<PropertyPurpose> propertyPurposes);
    }
}
