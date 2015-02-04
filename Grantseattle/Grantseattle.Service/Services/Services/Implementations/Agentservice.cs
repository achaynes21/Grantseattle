using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Core;
using InventoryERP.Data;
using InventoryERP.Domain;
using InventoryERP.Services;
using InventoryERP.Services.ModelConverters;
using InventoryERP.Services.Models;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services.Implementations
{
    public class Agentservice:BaseService,IAgentService
    {
        private IRepository<Agent> AgentRepository { get; set; }

        public Agentservice(IRepository<Agent> newsRepository)
        {
            AgentRepository = newsRepository;
        }

        public Agent GetAgentById(string id)
        {
            return AgentRepository.GetById(id);
        }

       public void Save(Agent entity)
        {
            AgentRepository.Save(entity);
        }

        public void Delete(Agent entity)
        {
            entity.Status = Propertys.PropertyStatusText.Delete;
            entity.UpdatedAt = DateTime.UtcNow;
            AgentRepository.Save(entity);
        }

        public IList<Agent> GetAgentList()
        {
            return AgentRepository.GetQuery().Where(x => x.Status == Propertys.PropertyStatusText.Active).ToList();
        }

        public void Edit(Agent oldModelObj)
        {
            throw new NotImplementedException();
        }

    }
}
