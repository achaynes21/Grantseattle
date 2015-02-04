using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Domain;

namespace InvertoryERP.Core.Domain
{
    public class Propertys : Entity, IAggregateRoot
    {
        [Required]
        [Display(Name = "Property Description")]
        public virtual string Name { get; set; }
        [Display(Name = "Is Established")]
        public virtual bool IsEstablished { get; set; }
        public virtual string Location { get; set; }
        [Required]
        public virtual decimal Price { get; set; }
        [Display(Name = "Is Price Display")]
        public virtual int IsPriceDisplay { get; set; }
        [Display(Name = "Price In Word")]
        public virtual string PriceText { get; set; }

        public virtual IList<PropertyImages> PropertyImageses { get; set; }
        
        public virtual Agent Agent { get; set; }
        public virtual PropertyType PropertyType { get; set; }
        public virtual PropertyLocationType PropertyLocationType { get; set; }
        public virtual PropertyPurpose PropertyPurpose { get; set; }
        public virtual PropertyDetails PropertyDetails { get; set; }
        public class PropertyStatusText
        {
            public static int Active
            {
                get { return 1; }
            }

            public static int Delete
            {
                get { return -1; }
            }


        }
        public class PropertyPrizeText
        {
            public static int ShowRealPrice
            {
                get { return 0; }
            }

            public static int ShowText
            {
                get { return 1; }
            }

            public static int Hide
            {
                get { return 2; }
            }
        }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
