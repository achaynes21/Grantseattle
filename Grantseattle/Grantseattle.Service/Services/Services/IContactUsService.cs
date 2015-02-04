using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvertoryERP.Core.Domain;

namespace InventoryERP.Service.Services.Services
{
    public interface IContactUsService
    {
        ContactUs GetAgentById(string id);
        void Save(ContactUs entity);
        void Delete(ContactUs entity);
        IList<ContactUs> GetAgentList();
    }
}
