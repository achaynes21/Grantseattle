using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InventoryERP.Core
{
    public class App
    {               
        private static ConfigurationVariables _configurations;
        public static ConfigurationVariables Configurations { get { return _configurations ?? (_configurations = new ConfigurationVariables()); } }

        private static CookieVariables _cookies;
        public static CookieVariables Cookies { get { return _cookies ?? (_cookies = new CookieVariables()); } }                
    }
}
