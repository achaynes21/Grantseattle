using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Domain;

namespace InvertoryERP.Core.Domain
{
    public class PropertyPurpose : Entity, IAggregateRoot
    {
        public virtual string Name { get; set; }
        public virtual int ProPurpose { get; set; }
        //public virtual Propertys Propertys { get; set; }

        public class PropertyPurposeText
        {
            public static int Rent
            {
                get { return 1; }
            }

            public static int Sell
            {
                get { return 2; }
            }

        }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
