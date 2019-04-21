using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace EmailSenderProgram
{
    class SmtpMailSender
    {

        public class MailSender
        {

            string _sender = "";
            string _password = "";

            public MailSender(string sender, string password)
            {
                _sender = sender;
                _password = password;
            }

            public void SendMail(string recipient, string subject, string message)
            {

                SmtpClient client = new SmtpClient("smtp.live.com");

                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential(_sender, _password);

                try
                {
                    var mail = new MailMessage(_sender.Trim(), recipient.Trim());
                    mail.Subject = subject;
                    mail.Body = message;
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }

        }

    }
}
