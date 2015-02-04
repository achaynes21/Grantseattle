using InventoryERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services
{
    public interface ICountryService
    {
        IList<Country> GetAllCountry();
        Country GetCountryById(string id);
        Country GetCountryByName(string name);
        Country GetCountryByCode(string code);
        Country GetCountryByFlag(string flag);
    }
}
