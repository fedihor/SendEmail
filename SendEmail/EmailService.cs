using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace SendEmail
{
    /// <summary>
    /// Для того, чтобы отправлять почту через gmail.com нужно после авторизации в аккаунте gmail.com перейти по этой ссылке
    /// и отметить "Небезопасные приложения разрешены" ("Allow less secure apps"):
    /// https://www.google.com/settings/security/lesssecureapps
    /// </summary>
    public class EmailService
    {
        public SmtpClient client = null;
        public string Host = "smtp.gmail.com";
        public int Port = 587;
        public string MailFrom = "MailFrom@gmail.com";
        public string Password = "Password";
        public bool IsBodyHtml = true;
        public List<string> Erors { get; private set; }

        public string MailTo { get; set; }
        public virtual string Subject { get; set; }
        public virtual string Body { get; set; }

        public SmtpClient SendBySmtp()
        {
            try
            {
                // Адрес и порт smtp-сервера, с которого мы и будем отправлять письмо.
                client = new SmtpClient(Host, Port);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(MailFrom, Password);
                client.EnableSsl = true;

                // Создаем письмо.
                using (MailMessage mail = new MailMessage(MailFrom, MailTo) { Subject = Subject, Body = Body, IsBodyHtml = true })
                {
                    // Отправить письмо.
                    client.Send(mail);
                }
            }
            catch (Exception ex)
            {
                Erors = new List<string>();
                Erors.Add(ex.Message);
                throw new Exception(ex.Message, ex);
            }

            return client;
        }
    }
}
