using System;

namespace InventoryERP.Domain
{
    public interface IAggregateRoot : IEntity
    {
        int Status { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}