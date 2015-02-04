using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IBlogPostService
    {
        BlogContent GetById(string id);
        void Save(BlogContent entity);
        void Delete(BlogContent entity);
        IList<BlogContent> GetList();
        //IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model);

        void Edit(BlogContent oldModelObj);
    }
}
