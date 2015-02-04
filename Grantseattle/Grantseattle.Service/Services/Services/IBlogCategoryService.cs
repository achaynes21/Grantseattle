using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Services;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IBlogCategoryService
    {
        BlogCategory GetById(string id);
        void Save(BlogCategory entity);
        void Delete(BlogCategory entity);
        IList<BlogCategory> GetList();
        //IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model);

        void Edit(BlogCategory oldModelObj);
    }
}
