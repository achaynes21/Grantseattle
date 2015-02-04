using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Security.Principal;
using System.Security.Permissions;

namespace InventoryERP.Core
{
    public static class Authentication
    {
        public static void SaveAuthenticationInformation(string userId, string userName, string role, bool rememberMe, string name, string friendlyURL)
        {
            SaveAuthenticationInformation(userId, userName, new List<string> { role }, rememberMe, name, friendlyURL);
        }
        public static void SaveAuthenticationInformation(string userId, string userName, List<string> roles, bool rememberMe, string name, string friendlyURL)
        {
            Check.Argument.Null(HttpContext.Current, "Current HttpContext");

            var strRoles = new StringBuilder();
            roles.ForEach(x => strRoles.Append(x + "|"));
            var allRoles = strRoles.ToString().Remove(strRoles.ToString().LastIndexOf("|"), 1);

            var authTicket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.UtcNow,
                rememberMe ? DateTime.UtcNow.AddYears(1) : DateTime.UtcNow.AddMinutes(60),
                rememberMe,
                userId + "|" + name + "|" + friendlyURL + "|" + allRoles);

            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            HttpContext.Current.Response.Cookies.Add(authCookie);
        }

        [SecurityPermission(SecurityAction.Demand, ControlPrincipal = true)]
        public static void LoadAuthenticationInformation()
        {
            if (HttpContext.Current.User != null && (HttpContext.Current.User is UserPrincipal)) return;

            var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return;

            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if (authTicket == null) return;

            var identity = new FormsIdentity(authTicket);

            var userId = authTicket.UserData.Split('|')[0];
            var fullName = authTicket.UserData.Split('|')[1];            
            var friendlyUrl = authTicket.UserData.Split('|')[2];
            var roles = authTicket.UserData.Split('|').Where((val, index) => index != 0 && index != 1 && index != 2).ToArray();

            HttpContext.Current.User = new UserPrincipal(identity, userId, roles, fullName, friendlyUrl);
        }
    }
}
