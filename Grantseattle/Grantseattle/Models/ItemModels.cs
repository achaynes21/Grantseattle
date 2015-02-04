using InventoryERP.Core;
using InventoryERP.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryERP.Web.Models
{
    public class ItemEditModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter the item name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter the brand name.")]
        public string BrandName { get; set; }
        [Required(ErrorMessage = "Please enter the model number.")]
        public string ModelNo { get; set; }
        [Required(ErrorMessage = "Please enter the price.")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public double Price { get; set; }
    }

    public class ItemListViewModel
    {
        public int PageIndex { get; set; }
        public string SearchString { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
        public IPagedList<ItemListShortViewModel> Items { get; set; }
    }
}