using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryERP.Domain;

namespace InvertoryERP.Core.Domain
{
    public class PropertyImages : Entity, IAggregateRoot
    {
        [Display(Name = "Image Url")]
        public virtual string ImageUrl { get; set; }
        public virtual string Caption { get; set; }
        [Display(Name = "Image Description")]
        public virtual string Imagedescription { get; set; }
        public virtual string ThumbUrl { get; set; }

        public virtual Propertys Property { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
