using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using InventoryERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Data.Mapping
{
    public class EntityMap
    {
        public static void Register()
        {
            BsonClassMap.RegisterClassMap<Entity>(cm =>
            {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(p => p.Id));
                cm.IdMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }
    }
}
