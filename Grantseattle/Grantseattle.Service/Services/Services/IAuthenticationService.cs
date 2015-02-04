using InventoryERP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services
{
    public interface IAuthenticationService
    {
        Member LoginAsMember(string username, string password, bool rememberMe);
        bool FacebookLoginAsMember(string username, bool rememberMe);
        void Logout();
    }
}
