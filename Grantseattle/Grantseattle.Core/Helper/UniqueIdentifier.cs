using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace InventoryERP.Core
{
    public class UniqueIdentifier
    {
        public static string New()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
