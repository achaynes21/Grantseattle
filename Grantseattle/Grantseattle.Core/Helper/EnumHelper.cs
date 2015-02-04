using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.WebPages.Html;
using SelectListItem = System.Web.Mvc.SelectListItem;

namespace InventoryERP.Core
{    
    public class EnumHelper
    {
        public static List<SelectListItem> EnumToList<T>(bool sameTextValue = false)
        {
            var source = (T[])(Enum.GetValues(typeof(T)).Cast<T>());

            var query = from enumItem in source 
                        let field = enumItem.GetType().GetField(enumItem.ToString()) 
                        let attr = field.GetCustomAttributes(typeof (DisplayAttribute), false).FirstOrDefault() as DisplayAttribute 
                        let text = attr == null ? Enum.GetName(typeof (T), enumItem) : attr.Name 
                        let value = sameTextValue ? text : (Convert.ChangeType(enumItem, Enum.GetUnderlyingType(typeof (T)))).ToString() 
                        select new SelectListItem {Text = text, Value = value};

            return query.ToList();
        }
        public static TEnum EnumInstanceFromValue<TEnum>(object value)
        {
            return (TEnum)Enum.ToObject(typeof(TEnum), value);
        } 
        public static string DisplayTextFromValue<TEnum>(object value)
        {
            var enumValue = EnumInstanceFromValue<TEnum>(value);
            var enumType = enumValue.GetType();
            var field = enumType.GetField(enumValue.ToString());
            var attribute = field.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            return attribute == null ? enumValue.ToString() : attribute.Name;            
        }
        public static string DisplayTextFromValue(Type type, object value)
        {
            var enumValue = Enum.ToObject(type, value);    
            var enumType = enumValue.GetType();
            var field = enumType.GetField(enumValue.ToString());
            var attribute = field.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;

            return attribute == null ? enumValue.ToString() : attribute.Name;  
        }
    }
}