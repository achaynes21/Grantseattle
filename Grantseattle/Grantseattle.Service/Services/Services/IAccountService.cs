using InventoryERP.Core;
using InventoryERP.Domain;
using InventoryERP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services
{
    public interface IAccountService
    {
        Member CreateMember(CreateMemberModel model);
        void SaveMember(Member entity);
        Member GetUserByEmail(string email);
        Member GetUserById(string id);
        Member GetMemberByEmailVerificationCode(string code);
        string SetResetPasswordCode(string email);
        Member GetMemberByResetPasswordCodeEmail(string code, string email);
        bool CheckForValidResetPassword(string email, string passwordResetCode);
        void ResetPassword(string email, string newPassword);
    }
}
