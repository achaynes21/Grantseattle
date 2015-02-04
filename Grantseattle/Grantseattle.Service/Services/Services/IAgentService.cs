using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IAgentService

    {
        Agent GetAgentById(string id);
        void Save(Agent entity);
        void Delete(Agent entity);
        IList<Agent> GetAgentList();
        //IPagedList<ItemListShortViewModel> GetItemList(GeneralCriteriaModel model);

        void Edit(Agent oldModelObj);
    }
}
