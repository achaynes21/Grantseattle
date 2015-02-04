using System.Security.Principal;

namespace InventoryERP.Core
{
    public sealed class UserPrincipal : GenericPrincipal
    {
        public string UserId { get; private set; }
        public string FullName { get; private set; }
        public string FriendlyURL { get; private set; }

        public UserPrincipal(IIdentity identity, string userId, string[] roles, string fullName, string friendlyURL)
            : base(identity, roles)
        {
            UserId = userId;
            FullName = fullName;
            FriendlyURL = friendlyURL;
        }
    }
}