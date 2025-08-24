using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailing
{
    public class MailManager
    {
        private readonly IMailService _mailService;
        public MailManager(IMailService mailService)
        {
            _mailService = mailService;
        }
        public void SendDepositRequestNotification(string tenantFullName, string toEmail)
        {
            Mail mail = new Mail
            {
                Subject = "Yeni Deposit Request",
                TextBody = $"Merhaba {tenantFullName},\n\nLandlord size yeni bir depozito talebi gönderdi. Lütfen sisteme giriş yaparak kabul veya reddedin.",
                HtmlBody = $"<p>Merhaba <b>{tenantFullName}</b>,</p><p>Landlord size yeni bir <b>depozito talebi</b> gönderdi.</p><p>Lütfen sisteme giriş yaparak kabul veya reddedin.</p>",
                ToFullName = tenantFullName,
                ToEmail = toEmail
            };
            _mailService.SendMail(mail);
        }
    }
}
