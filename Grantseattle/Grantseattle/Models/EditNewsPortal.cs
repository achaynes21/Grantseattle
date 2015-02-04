using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryERP.Models
{
    public class EditNewsPortal
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter the News Heading.")]
        public string Heading { get; set; }
        
        
        [Required(ErrorMessage = "Please enter the News Description.")]
        
        public string NewsDescription { get; set; }

        public string Source { get; set; }
        public string ImageUrl { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase UploadImage { get; set; }
       
    }
}