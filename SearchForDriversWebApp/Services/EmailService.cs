using MimeKit;
using MailKit.Net.Smtp;
using System.Net.Mail;
using System.Net;

namespace SearchForDriversWebApp.Services
{
    public class EmailService
    {
        private readonly ILogger<EmailService> logger;

        public EmailService(ILogger<EmailService> logger)
        {
            this.logger = logger;
        }

        //System.Net.Mail.SmtpClient
        public void SendEmailDefault(string sender, string messageText)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Yavir Admin", "admin@mycompany.com"));
                message.To.Add(new MailboxAddress("Recipient Name", $"{sender}"));
                message.Subject = "Yavir";
                message.Body = new TextPart("html") { Text = $"<div style=\"color: black;\">{messageText}</div>" };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("bohdanets_ak20@nuwm.edu.ua", "june1506!");
                    client.Send(message);
                    client.Disconnect(true);
                    logger.LogInformation("Сообщение отправлено успешно!");
                }
            }
            catch (Exception e)
            {
                logger.LogError(e.GetBaseException().Message);
            }
        }

        //MailKit.Net.Smtp.SmtpClient
        //public void SendEmailCustom()
        //{
        //    try
        //    {
        //        MimeMessage message = new MimeMessage();
        //        message.From.Add(new MailboxAddress("Моя компания", "admin@mycompany.com")); //отправитель сообщения
        //        message.To.Add(new MailboxAddress("mail@yandex.ru")); //адресат сообщения
        //        message.Subject = "Сообщение от MailKit"; //тема сообщения
        //        message.Body = new BodyBuilder() { HtmlBody = "<div style=\"color: green;\">Сообщение от MailKit</div>" }.ToMessageBody(); //тело сообщения (так же в формате HTML)

        //        using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
        //        {
        //            client.Connect("smtp.gmail.com", 587, true); //либо использум порт 465
        //            client.Authenticate("mail@gmail.com", "secret"); //логин-пароль от аккаунта
        //            client.Send(message);

        //            client.Disconnect(true);
        //            logger.LogInformation("Сообщение отправлено успешно!");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        logger.LogError(e.GetBaseException().Message);
        //    }
        //}
    }
}
