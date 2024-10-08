using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Abstract
{
    public interface IMailService
    {
        void SendMail(SendMailViewModel sendMailViewModel);
    }
}
