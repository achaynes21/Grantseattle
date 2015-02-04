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
using System.Web;
using System.Web.Security;
using System.IO;

namespace InventoryERP.Services.Implementations
{
    public class EmailService : BaseService, IEmailService
    {
        protected string TemplateFolder { get; private set; }

        protected IRepository<Member> MemberRepository { get; private set; }

        public EmailService(IRepository<Member> memberRepository)
        {
            if (HttpContext.Current != null)
            {
                string path = HttpContext.Current.Server.MapPath(App.Configurations.EmailTemplatePath.Value);
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);

                TemplateFolder = path;
            }

            MemberRepository = memberRepository;
        }

        public void SendMessage(string receiverEmail, string receiverName, string senderName, string messageText)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.SendMessage.Value);
            string subject = App.Configurations.SendMessageSubject.Value;
            string loginLink = LinkHelper.Domain + (LinkHelper.Domain.EndsWith("/") ? "" : "/") + "log-in";

            body = body.Replace("$ReceiverName$", receiverName);
            body = body.Replace("$SenderName$", senderName); //LinkHelper.Domain + (LinkHelper.Domain.EndsWith("/") ? "" : "/") + "confirm-email?code={0}".FormatWith(activationCode));
            body = body.Replace("$MessageText$", messageText);
            body = body.Replace("$Recipient$", receiverEmail);
            body = body.Replace("$Login$", loginLink);



            Dictionary<string, string> receivers = new Dictionary<string, string>();

            receivers.Add(receiverEmail, receiverName);

            EmailSender.Send(receivers, subject, body);
        }

        public void SendEmailVarification(string name, string email, string activationCode)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.EmailVerification.Value);
            string subject = App.Configurations.EmailVerificationSubject.Value;

            body = body.Replace("$Name$", name);
            body = body.Replace("$Link$", LinkHelper.Domain + (LinkHelper.Domain.EndsWith("/") ? "" : "/") + "confirm-email?code={0}".FormatWith(activationCode));
            body = body.Replace("$Recipient$", email);

            Dictionary<string, string> receivers = new Dictionary<string, string>();
            receivers.Add(email, name);

            EmailSender.Send(receivers, subject, body);
        }

        public void SendForgotPassword(string name, string email, string resetPasswordCode)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            //string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.ForgotPassword.Value);
            //string body = System.IO.File.ReadAllText(App.Configurations.ForgotPassword.Value);
            //string subject = App.Configurations.ForgotPasswordSubject.Value;

            //body = body.Replace("$Link$", LinkHelper.Domain + (LinkHelper.Domain.EndsWith("/") ? "" : "/") + "reset-password?code={0}&email={1}".FormatWith(resetPasswordCode, email));
            //body = body.Replace("$Recipient$", email);

            string subject = "Forget Password Grantseattle";

            string body = "Dear" + name + "Your current password for grantseattle Is " + resetPasswordCode;
            Dictionary<string, string> receivers = new Dictionary<string, string>();
            receivers.Add(email, name);

            EmailSender.Send(receivers, subject, body);
        }

        public void SendSubscriptionNotification(string subscriptionEmail, string receiverEmail, string count)
        {
            if (TemplateFolder.IsNullOrWhiteSpace()) return;

            string body = System.IO.File.ReadAllText(TemplateFolder + "\\" + App.Configurations.EmailSubscription.Value);
            string subject = App.Configurations.EmailSubscriptionSubject.Value;

            body = body.Replace("$Email$", subscriptionEmail);
            body = body.Replace("$Count$", count);
            body = body.Replace("$Recipient$", receiverEmail);

            EmailSender.Send(receiverEmail, subject, body);
        }

    }
}
