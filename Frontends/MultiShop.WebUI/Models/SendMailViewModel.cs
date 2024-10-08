namespace MultiShop.WebUI.Models
{
    public class SendMailViewModel
    {
        public List<string> ReceiverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsSend { get; set; }
    }
}
