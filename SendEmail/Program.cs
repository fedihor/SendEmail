namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailService EmailSender = new EmailService();
            EmailSender.MailTo = "MailTo@ukr.net";
            EmailSender.Subject = "Заголовок";
            EmailSender.Body = "<h1><font color='red'>Тіло листа.</font></h1>";
            EmailSender.SendBySmtp();
        }
    }
}
