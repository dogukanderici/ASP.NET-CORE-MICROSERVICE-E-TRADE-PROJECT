using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Services.Concrete
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public void SendMail(SendMailViewModel sendMailViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();

            // Gönderen Bilgisi
            MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop", _mailSettings.Sender);
            mimeMessage.From.Add(mailboxAddressFrom);

            // Alıcı Bilgisi
            foreach (var item in sendMailViewModel.ReceiverMail)
            {
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", item);
                mimeMessage.To.Add(mailboxAddressTo);
            }

            // Mail Konusu

            mimeMessage.Subject = sendMailViewModel.Subject;

            // Mail İçeriği
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = sendMailViewModel.Body;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            // Smtp Client Oluşturulur.

            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Connect(_mailSettings.SmtpServer, _mailSettings.SmtpPort, false);
                smtpClient.Authenticate(_mailSettings.Sender, _mailSettings.MailApiKey);
                smtpClient.Send(mimeMessage);
                smtpClient.Disconnect(true);
            }
        }
    }
}
