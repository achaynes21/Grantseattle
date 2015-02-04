using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services.Models
{
    public class ItemListShortViewModel
    {
        public string Name { get; set; }
        public string BrandName { get; set; }
        public string ModelNo { get; set; }
        public double Price { get; set; }
        public string CreatedAt { get; set; }
    }


}
