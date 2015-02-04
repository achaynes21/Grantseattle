using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Models
{
    public class PropertyImagesModelView
    {
        [Display(Name = "Upload Images")]
        public virtual string ImageUrl { get; set; }
        public virtual string Caption { get; set; }
        [Display(Name = "Image Description")]
        public virtual string Imagedescription { get; set; }

        public virtual Propertys Property { get; set; }
        //public virtual HttpPostedFileBase ImgFile { get; set; }
    }
}