using InventoryERP.Core;
using InventoryERP.Data;
using InventoryERP.Domain;
using InventoryERP.Services.Models;
using InventoryERP.Services.ModelConverters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Services.Implementations
{
    public class AccountService : BaseService, IAccountService
    {
        protected IRepository<Member> MemberRepository { get; private set; }

        public AccountService(IRepository<Member> memberRepository)
        {
            MemberRepository = memberRepository;
        }

        public Member CreateMember(CreateMemberModel model)
        {
            Member entity = new Member();
            entity.Role = "Member";
            model.ToMember(entity);
            MemberRepository.Save(entity);

            return entity;
        }

        public void SaveMember(Member entity)
        {
            MemberRepository.Save(entity);
        }

        public Member GetUserByEmail(string email)
        {
            return MemberRepository.GetQuery().FirstOrDefault(x => x.Email == email && !x.Deleted && !x.Deactivated);
        }

        public Member GetUserById(string id)
        {
            return MemberRepository.GetById(id);
        }
        
        public Member GetMemberByEmailVerificationCode(string code)
        {
            return MemberRepository.GetQuery().FirstOrDefault(x => x.EmailVerificationCode == code && !x.Deleted && !x.Deactivated);
        }

        public string SetResetPasswordCode(string email)
        {
            var member = GetUserByEmail(email);

            member.PasswordResetCode = Guid.NewGuid().NewGuidString();
            member.PasswordResetCodeExpired = DateTime.UtcNow.AddDays(3);

            MemberRepository.Save(member);

            return member.PasswordResetCode;
        }

        public Member GetMemberByResetPasswordCodeEmail(string code, string email)
        {
            return MemberRepository.GetQuery().FirstOrDefault(x => x.PasswordResetCode == code && x.Email == email && !x.Deleted && !x.Deactivated);
        }

        public bool CheckForValidResetPassword(string email, string passwordResetCode)
        {
            var member = MemberRepository.GetQuery().FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && !x.Deleted && !x.Deactivated);
            if (member != null)
            {
                if (passwordResetCode != member.PasswordResetCode) return false;

                return true;
            }

            return false;
        }

        public void ResetPassword(string email, string newPassword)
        {
            var member = MemberRepository.GetQuery().FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && !x.Deleted && !x.Deactivated);

            if (member != null)
            {
                member.Password = newPassword;
                member.PasswordResetCode = String.Empty;
                MemberRepository.Save(member);
            }
        }
    }
}
