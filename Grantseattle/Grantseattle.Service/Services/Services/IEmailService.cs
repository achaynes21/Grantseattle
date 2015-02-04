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
    public interface IEmailService
    {
        void SendEmailVarification(string name, string email, string activationCode);
        void SendMessage(string receiverEmail, string receiverName, string senderName, string messageText);
        void SendForgotPassword(string name, string email, string resetPasswordCode);
        void SendSubscriptionNotification(string subscriptionEmail, string receiverEmail, string count);
    }
}
