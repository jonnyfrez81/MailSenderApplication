using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EmailSenderProgram
{
    /// <summary>
    /// This is the EmailSender.
    /// I'm using my private mail to send and recive.
    /// </summary>
        public class EmailSender
        {
            string _sender = "";
            string _password = "";

            public EmailSender(string sender, string password)
            {
                _sender = sender;
                _password = password;
            }

            /// <summary>
            /// This is the motor for the application
            /// Here we create the connection to the mail server (smtp) in this case we are using smtpl.live.com to send mail from hotmail.
            /// this method can be called from diffrent types of mail: New customer as old customer...
            /// </summary>
            /// <param name="recipient"></param>
            /// <param name="subject"></param>
            /// <param name="message"></param>
            public void SendMail(string recipient, string subject, string message)
            {
                SmtpClient client = new SmtpClient("smtp.live.com");

                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(_sender, _password);
                client.EnableSsl = true;
                client.Credentials = credentials;

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
