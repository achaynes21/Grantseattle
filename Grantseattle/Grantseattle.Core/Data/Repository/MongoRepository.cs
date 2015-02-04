using InvertoryERP.Core.Domain;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using InventoryERP.Data.Mapping;
using InventoryERP.Domain;
using InventoryERP.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace InventoryERP.Data.Implementations
{
    public partial class MongoRepository<TAggregateRoot> : IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        private MongoDatabase _database;
        private MongoCollection<TAggregateRoot> Collection
        {
            get
            {
                return _database.GetCollection<TAggregateRoot>(Inflector.Pluralize(typeof(TAggregateRoot).Name));
            }
        }

        public MongoRepository(MongoDatabase database)
        {
            _database = database;
        }

        public IQueryable<TAggregateRoot> GetQuery()
        {
            return this.Collection.AsQueryable<TAggregateRoot>();
        }
        public TAggregateRoot GetById(string id)
        {
            return this.GetQuery().FirstOrDefault(x => x.Id == id);
        }
        public void Save(TAggregateRoot entity)
        {
            Check.Argument.Null(entity, "entity");

            this.Collection.Save<TAggregateRoot>(entity);
        }
        public void AddRange(IEnumerable<TAggregateRoot> entities)
        {
            Check.Argument.Null(entities, "entities");

            this.Collection.InsertBatch<TAggregateRoot>(entities);
        }
        public bool Remove(string id)
        {
            Check.Argument.EmptyOrWhiteSpace(id, "id", "You must provide an id.");

            WriteConcernResult result = this.Collection.Remove(Query.EQ("_id", id));

            return result.DocumentsAffected > 0;
        }
        public void RemoveAll()
        {
            this.Collection.RemoveAll();
        }

        public IList<Propertys> GetPropertyBySearchingCriter(string cityName = "", string location = "", string propType = "", string bed = "", string minPrice = "",
            string maxPrice = "", string generalSearch = "")
        {
            var criteria = LinqExtensionMethods.AsQueryable<Propertys>((MongoCollection)this.Collection);

            if (!String.IsNullOrEmpty(cityName))
            {
                criteria = criteria.Where(x => x.PropertyDetails.StreetAddress1.Contains(cityName));
            }
            if (!String.IsNullOrEmpty(location))
            {
                criteria = criteria.Where(x => x.Location.Contains(location));
            }
            if (!String.IsNullOrEmpty(bed))
            {
                criteria = criteria.Where(x => x.PropertyDetails.BedCount >= Convert.ToInt32(bed));
            }
            if (propType.Equals("0")) { }
            else if (!String.IsNullOrEmpty(propType))
            {
                criteria = criteria.Where(x => x.PropertyType.Id == propType);
            }
            if (!String.IsNullOrEmpty(minPrice))
            {
                criteria = criteria.Where(x => x.Price >= Convert.ToInt32(minPrice));
            }
            if (!String.IsNullOrEmpty(maxPrice))
            {
                criteria = criteria.Where(x => x.Price <= Convert.ToInt32(maxPrice));
            }
            if (!String.IsNullOrEmpty(generalSearch))
            {
                criteria = criteria.Where(x => x.Agent.FirstName.Contains(generalSearch) || x.Location.Contains(generalSearch));
            }
            var result = criteria.ToList();
            return result;
        }

        public IList<Propertys> GetPropertyBySearchingCriterAgent(string cityName, string location, string propType, string agentName,
            string generalSearch)
        {
            var criteria = LinqExtensionMethods.AsQueryable<Propertys>((MongoCollection)this.Collection);

            if (!String.IsNullOrEmpty(cityName))
            {
                criteria = criteria.Where(x => x.PropertyDetails.StreetAddress1.Contains(cityName));
            }
            if (!String.IsNullOrEmpty(location))
            {
                criteria = criteria.Where(x => x.Location.Contains(location));
            }
            if (propType.Equals("0")) { }
            else if (!String.IsNullOrEmpty(propType))
            {
                criteria = criteria.Where(x => x.PropertyType.Id == propType);
            }
            if (!String.IsNullOrEmpty(agentName))
            {
                criteria = criteria.Where(x => x.Agent.FirstName.Contains(agentName) || x.Agent.LastName.Contains(agentName));
            }
            if (!String.IsNullOrEmpty(generalSearch))
            {
                criteria = criteria.Where(x => x.Agent.FirstName.Contains(generalSearch) || x.Location.Contains(generalSearch));
            }
            var result = criteria.ToList();
            return result;
        }
    }
}