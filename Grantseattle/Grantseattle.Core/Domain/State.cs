using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryERP.Domain
{
    public class State : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
