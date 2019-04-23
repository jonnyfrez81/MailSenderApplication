using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram
{
    class Constant
    {

        public static class Mail
        {
            public const string from = "infor@cdon.com";
        }

        /// <summary>
        /// All strings for NewCustomerMail
        /// </summary>
        public static class NewCustomerMail
        {
            public const string sendingWelcomeMail = "Sending welcome mail!";
            public const string notSendingNewCustomerMail = "No welcome mail were sent!";
            public const string newCustomerMailSent = "New Customer Mails were sent";
            public const string newCustomerMailNotSent = "No new Customers were in the list";
            public const string newCustomerSubject = "Welcome as a new customer at CDON!";
            public const string newCustomerBody = "We would like to welcome you as customer on our site! \n Best Regards, CDON Team";

        }

        /// <summary>
        /// All strings for OldCustomerMail
        /// </summary>
        public static class OldCustomerMail
        {
            public const string sendingComeBackMail = "Sending comeback mail!";
            public const string notSenndingComeBackMail = "No comback mail were sent!";
            public const string oldCustomerMailSent = "Old Customer reminder mails were sent";
            public const string oldCustomerMailNotsent = "No old customer where sent";
            public const string oldCustomerMailSubject = "We miss you as a customer";
            public const string oldCustomerBody = "We miss you as a customer. Our shop is filled with nice products. Here is a voucher that gives you 50 kr to shop for." +
                                                  "Voucher: CDONComebackToUs Best Regards, CDON Team";

        }

        public static class MailCredentials
        {
            public const string userName = "InsertMailAddress";
            public const string password = "InsertMailPassword";
        }
    }
}
