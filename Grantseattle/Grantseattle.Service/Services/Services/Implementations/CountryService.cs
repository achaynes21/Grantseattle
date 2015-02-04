using InventoryERP.Data;
using InventoryERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services.Implementations
{
    public class CountryService : BaseService, ICountryService
    {
        protected IRepository<Country> CountryRepository { get; private set; }
        public CountryService(IRepository<Country> countryRepository)
        {
            CountryRepository = countryRepository; 
        }

        public IList<Country> GetAllCountry()
        {
            return CountryRepository.GetQuery().OrderBy(x => x.Name).ToList<Country>();
        }

        public Country GetCountryById(string id)
        {
            return CountryRepository.GetById(id);
        }

        public Country GetCountryByName(string name)
        {
            return CountryRepository.GetQuery().FirstOrDefault(x => x.Name == name);
        }

        public Country GetCountryByCode(string code)
        {
            return CountryRepository.GetQuery().FirstOrDefault(x => x.Code == code);
        }

        public Country GetCountryByFlag(string flag)
        {
            return CountryRepository.GetQuery().FirstOrDefault(x => x.FlagImage == flag);
        }
    }
}
