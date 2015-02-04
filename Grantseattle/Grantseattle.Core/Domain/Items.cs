using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Domain
{
    public class Item : Entity ,IAggregateRoot
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ModelNo { get; set; }
        public double Price { get; set; }

        public bool Delivered { get; set; }
        public bool Deleted { get; set; }

        public Member CreatedBy { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
