using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InventoryERP.Core
{
    public class DataTypeConverter
    {
        public static object ChangeType(object value, Type conversionType)
        {
            if (conversionType == null) throw new ArgumentNullException("conversionType");

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null) return null;

                var nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }            

            return Convert.ChangeType(value, conversionType);
        }

        public static T Cast<T>(object obj)
        {
            return (T)obj;
        }
    }
}
