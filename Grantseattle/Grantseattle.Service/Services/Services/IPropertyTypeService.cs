using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IPropertyTypeService
    {
        PropertyType GetById(string id);
        void Save(PropertyType entity);
        void Delete(PropertyType entity);
        IList<PropertyType> GetList();
        //IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model);

        void Edit(PropertyType oldModelObj);
    }
}
