using InventoryERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services
{
    public interface IStateService
    {
        IList<State> GetAllState();
        State GetStateById(string id);
        State GetStateByName(string name);
        State GetStateByCode(string code);
    }
}
