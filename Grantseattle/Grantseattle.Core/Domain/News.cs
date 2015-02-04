using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using InventoryERP.Domain;

namespace InvertoryERP.Core.Domain
{
    public class News : Entity, IAggregateRoot
    {
        public string Heading { get; set; }
        
        public string NewsDescription { get; set; }
        public bool IsDelete { get; set; }
        public string Source { get; set; }
        public string ImageUrl { get; set; }
        public Member CreatedBy { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Member Member { get; set; }
    }
}
