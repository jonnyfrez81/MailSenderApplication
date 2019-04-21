using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram.MailTypes
{
    class NewCustomerMail
    {

        /// <summary>
        /// This is where we create new mails.
        /// </summary>
        /// <returns></returns>
        public static bool WelcomMail()
        {
            bool succes = false;

            try
            {     
                //List all customers
                List<Customer> customer = DataLayer.ListCustomers();
                //loop through list of new customers
                for (int i = 0; i < customer.Count; i++)
                {
                    //If the customer is newly registered, one day back in time
                    if (customer[i].CreatedDateTime >= DateTime.Now.AddDays(-1))
                    {

                        var sender = new EmailSender(Constant.MailCredentials.userName, Constant.MailCredentials.password);
                        sender.SendMail(customer[i].Email, Constant.Mail.from, Constant.NewCustomerMail.newCustomerSubject  + " Hi " + customer[i].Email.Substring(0, customer[i].Email.LastIndexOf("@")) + " " + Constant.NewCustomerMail.newCustomerBody);
                        succes = true;
                        
                        //We take a way the charecters after the @ sign. 
                        Console.WriteLine("Send welcome mail to:" + customer[i].Email.Substring(0, customer[i].Email.LastIndexOf("@")));
                    }
                }
                //All mails are sent! Success!
                return succes;
                ;
            }
            catch (Exception)
            {
                //Something went wrong :(
                return false;
            }
        }

    }
}
