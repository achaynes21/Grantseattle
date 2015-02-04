using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Models
{
    public class PropertyDetailsModelView
    {
        public virtual string Unit { get; set; }

        [Display(Name = "Address")]
        public virtual string StreetAddress1 { get; set; }
        [Display(Name = "Location")]
        public virtual string StreetAddress2 { get; set; }
        [Display(Name = "Hide Street Address")]
        public virtual bool IsHideStreetAddress { get; set; }
        [Display(Name = "Hide Street View")]
        public virtual bool IsHideStreetView { get; set; }
        [Display(Name = "Suberb")]
        public virtual string Suberb { get; set; }
        public virtual string Municipility { get; set; }
        [Display(Name = "Bed")]
        public virtual int BedCount { get; set; }
        [Display(Name = "Parking")]
        public virtual int ParkingCount { get; set; }
        [Display(Name = "Bath")]
        public virtual int BathCount { get; set; }
        [Display(Name = "Area")]
        public virtual int AreaCount { get; set; }

        public virtual Propertys Property { get; set; }
        
    }
}