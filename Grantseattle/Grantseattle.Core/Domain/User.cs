using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryERP.Domain
{
    public class User : Entity, IAggregateRoot
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordResetCode { get; set; }
        public string EmailVerificationCode { get; set; }
        public bool EmailVerified { get; set; }
        public bool Deleted { get; set; }
        public bool Deactivated { get; set; }

        public DateTime? PasswordResetCodeExpired { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }        
    }
}
