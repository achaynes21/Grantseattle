using InventoryERP.Domain;
using InventoryERP.Services.Models;
using InventoryERP.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services.ModelConverters
{
    public static class AccountServiceModelConverters
    {
        public static Member ToMember(this CreateMemberModel souce, Member target)
        {
            target.Email = souce.Email;
            target.FirstName = souce.FirstName;
            target.LastName = souce.LastName;
            target.Password = souce.Password;
            target.EmailVerificationCode = Guid.NewGuid().NewGuidString();
            target.CreatedAt = DateTime.UtcNow;
            target.Role = "Member";
            return target;
        }
    }
}
