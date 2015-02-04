using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Models
{
    public class PropertyModelView
    {
        [Display(Name = "Is Established")]
        public virtual bool IsEstablished { get; set; }

        [Required(ErrorMessage = "Price Required")]
        public virtual decimal Price { get; set; }

        [Required(ErrorMessage = "Price Required")]
        [Display(Name = "Price In Word")]
        public virtual string PriceinText { get; set; }

        [Display(Name = "Is Price Display")]
        public virtual int IsPriceDisplay { get; set; }

        [Required(ErrorMessage = "Please Add a Property Title")]
        public virtual string Title { get; set; }

        [Required(ErrorMessage = "Please Select a Property Type")]
        [Display(Name = "Property Type")]
        public virtual PropertyType PropertyType { get; set; } // Apartment

        [Required(ErrorMessage = "Please Select Property Location Type")]
        [Display(Name = "Property Location Type")]
        public virtual PropertyLocationType PropertyLocationType { get; set; } // Residential

        [Required(ErrorMessage = "Please Select Property Purpose Type")]
        [Display(Name = "Property Purpose Type")]
        public virtual PropertyPurpose PropertyPurposeType { get; set; } // Sell

        [Required(ErrorMessage = "Please Select a Agent")]
        public virtual Agent Agent { get; set; }
    }
}