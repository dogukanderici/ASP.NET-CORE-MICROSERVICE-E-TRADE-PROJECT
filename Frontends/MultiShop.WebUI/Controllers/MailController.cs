using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequestViewModel mailRequestViewModel)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop Admin", "dogukan.derici@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailBoxAddressTo = new MailboxAddress("User", mailRequestViewModel.ReceiverMail);
            mimeMessage.To.Add(mailBoxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequestViewModel.Content;

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = mailRequestViewModel.Subject;

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("dogukan.derici@gmail.com", "coillypqwmlgrauy ");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
