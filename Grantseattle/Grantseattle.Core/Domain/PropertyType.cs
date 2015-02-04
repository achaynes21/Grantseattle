using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Domain;

namespace InvertoryERP.Core.Domain
{
    public class PropertyType : Entity, IAggregateRoot
    {
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public virtual byte[] Image { get; set; }

        public virtual int PropertyTypeStatus { get; set; }

        public virtual IList<Propertys> Property { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
