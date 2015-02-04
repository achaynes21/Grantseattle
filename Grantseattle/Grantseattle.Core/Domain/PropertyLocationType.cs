using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Domain;

namespace InvertoryERP.Core.Domain
{
    public class PropertyLocationType : Entity, IAggregateRoot
    {
        public virtual string Name { get; set; }
        public virtual int ProLocationType { get; set; }

        public class PropertyLocationText
        {
            public static int Commercial
            {
                get { return 1; }
            }

            public static int Residential
            {
                get { return 2; }
            }

            public static int Rural
            {
                get { return 3; }
            }
        }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
