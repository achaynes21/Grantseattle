using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace InventoryERP.Core
{    
    public class DateTimeHelper
    {
        public static IList<int> AvailableYears()
        {
            var years = new List<int>();

            for (var year = DateTime.UtcNow.Year - 18; year > 1971; year--)
                years.Add(year);

            return years;
        }

        public static IList<int> AvailableDays()
        {
            var days = new List<int>();

            for (var day = 1; day <= 31; day++)
                days.Add(day);

            return days;
        }
    }
}