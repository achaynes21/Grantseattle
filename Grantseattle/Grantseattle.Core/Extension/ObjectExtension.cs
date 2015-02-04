using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Core
{
    public static class ObjectExtensions
    {
        public static T GetValue<T>(this object objectInstance, string propertyName)
        {
            Check.Argument.Null(objectInstance, "objectInstance");
            Check.Argument.EmptyOrWhiteSpace(propertyName, "propertyName");

            var propertyInfo = objectInstance.GetType().GetProperty(propertyName);

            if (propertyInfo.PropertyType.Equals(typeof(T)))
                return (T)propertyInfo.GetValue(objectInstance);

            return default(T);
        }
    }
}
