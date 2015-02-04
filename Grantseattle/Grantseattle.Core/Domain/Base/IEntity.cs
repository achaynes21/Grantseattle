using MongoDB.Bson;
using System;

namespace InventoryERP.Domain
{
    public interface IEntity
    {
        string Id { get; set; }
    }
}