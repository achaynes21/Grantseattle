using InventoryERP.Data;
using InventoryERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services.Implementations
{
    public class StateService : BaseService, IStateService
    {
        protected IRepository<State> StateRepository { get; private set; }

        public StateService(IRepository<State> stateRepository)
        {
            StateRepository = stateRepository;
        }

        public IList<State> GetAllState()
        {
            return StateRepository.GetQuery().ToList<State>();
        }

        public State GetStateById(string id)
        {
            return StateRepository.GetById(id);
        }

        public State GetStateByName(string name)
        {
            return StateRepository.GetQuery().FirstOrDefault(x => x.Name == name);
        }

        public State GetStateByCode(string code)
        {
            return StateRepository.GetQuery().FirstOrDefault(x => x.Code == code);
        }
    }
}
