using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IPropertyLocationService
    {
        PropertyLocationType GetById(string id);
        void Save(PropertyLocationType entity);
        void Delete(PropertyLocationType entity);
        IList<PropertyLocationType> GetList();
        //IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model);

        void Edit(PropertyLocationType oldModelObj);

        void SavePropertyLocation(IList<PropertyLocationType> locationTypes);
    }
}
