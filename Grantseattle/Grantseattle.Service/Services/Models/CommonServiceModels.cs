using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services.Models
{
    public class GeneralCriteriaModel
    {
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
