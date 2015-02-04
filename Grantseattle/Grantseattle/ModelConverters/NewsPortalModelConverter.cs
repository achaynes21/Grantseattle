using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryERP.Models;
using InvertoryERP.Core.Domain;

namespace InventoryERP.ModelConverters
{
    public static class NewsPortalModelConverter
    {
        public static News ToNews(this EditNewsPortal source, News target)
        {
            target.Id = source.Id;
            target.Heading = source.Heading;
            target.NewsDescription = source.NewsDescription;
            target.ImageUrl = source.ImageUrl;
            target.Source = source.Source;
            //target.CreatedBy = HttpContext.Current.use
            return target;
        }

        //public static ItemEditModel ToItemEditModel(this Item source)
        //{
        //    var target = new ItemEditModel();

        //    target.Id = source.Id;
        //    target.Name = source.Name;
        //    target.BrandName = source.BrandName;
        //    target.ModelNo = source.ModelNo;
        //    target.Price = source.Price;

        //    return target;
        //}

        //public static GeneralCriteriaModel ToGeneralCriteriaModel(this ItemListViewModel source)
        //{
        //    var target = new GeneralCriteriaModel();

        //    target.PageIndex = source.PageIndex;
        //    target.SearchString = source.SearchString;
        //    target.SortBy = source.SortBy;
        //    target.SortOrder = source.SortOrder;

        //    return target;
        //}
    }
}