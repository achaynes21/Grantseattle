using InventoryERP.Core;
using InventoryERP.Data;
using InventoryERP.Domain;
using InventoryERP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace InventoryERP.Services.Implementations
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        protected IRepository<Member> MemberRepository { get; private set; }
        protected IAccountService AccountService { get; private set; }

        public AuthenticationService(IRepository<Member> memberRepository, IAccountService accountService)
        {
            MemberRepository = memberRepository;
            AccountService = accountService;
        }

        public bool FacebookLoginAsMember(string username, bool rememberMe)
        {
            Member user = MemberRepository.GetQuery().FirstOrDefault(x => x.Email.ToLower() == username.ToLower() && !x.Deleted && !x.Deactivated);
            if (user == null) return false;

            Authentication.SaveAuthenticationInformation(user.Id, user.Email, "Member", true, user.FirstName + " " + user.LastName, user.FriendlyUrl);

            return true;
        }

        public Member LoginAsMember(string username, string password, bool rememberMe)
        {
            Member user = MemberRepository.GetQuery().FirstOrDefault(x => x.Email.ToLower() == username.ToLower() && x.Password == password && !x.Deleted && !x.Deactivated);
            if (user == null) //return false;
                return new Member();
            Authentication.SaveAuthenticationInformation(user.Id, user.Email, "Member", true, user.FirstName + " " + user.LastName, user.FriendlyUrl);

            //return true;
            return user;
        }

        public void Logout()
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }
    }
}
