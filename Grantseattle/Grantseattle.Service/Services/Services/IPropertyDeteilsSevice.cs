using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IPropertyDeteilsSevice
    {
        PropertyDetails GetById(string id);
        void Save(PropertyDetails entity);
        void Delete(PropertyDetails entity);
        IList<PropertyDetails> GetList();
        void Edit(PropertyDetails oldModelObj);
    }
}
