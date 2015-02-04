using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Domain;

namespace InvertoryERP.Core.Domain
{
    public class ContactUs : Entity, IAggregateRoot
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNum { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Message { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
