using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

using InventoryERP.Domain;

namespace InventoryERP.Data
{
    public partial interface IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        IQueryable<TAggregateRoot> GetQuery();
        TAggregateRoot GetById(string id);
        void Save(TAggregateRoot entity);
        void AddRange(IEnumerable<TAggregateRoot> entities);
        bool Remove(string id);
        void RemoveAll();


        IList<InvertoryERP.Core.Domain.Propertys> GetPropertyBySearchingCriter(string cityName, string location, string propType, string bed, string minPrice, string maxPrice, string generalSearch);

        IList<InvertoryERP.Core.Domain.Propertys> GetPropertyBySearchingCriterAgent(string cityName, string location, string propType, string agentName, string generalSearch);
    }
}
