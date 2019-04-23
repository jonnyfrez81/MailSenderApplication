using System;
using System.Data.SqlTypes;
using EmailSenderProgram.MailTypes;

namespace EmailSenderProgram
{
    internal class Program
    {
        /// <summary>
        /// This application is run everyday
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int customerListCount = DataLayer.ListCustomers().Count;//Sum of all customers
            int oldCustomerListCount = DataHelper.OldCustomersInList(DataLayer.ListCustomers(), DataLayer.ListOrders());//Count all the oldCustomers
            int newCustomerListCount = DataHelper.NewCustomerCount(DataLayer.ListCustomers());
            bool validateCustomerList = DataHelper.CheckListIfNull(DataLayer.ListCustomers()); //true if list has customer else false

            //Consol information
            Console.WriteLine("Total customers: " + customerListCount); 
            Console.WriteLine("Total old customers: " + oldCustomerListCount);
            Console.WriteLine("Total new customers: " + newCustomerListCount);
            
            //Information to user to see what the applikation is going to do.
            string sendNewCustomerMessage = newCustomerListCount >= 1 ? Constant.NewCustomerMail.sendingWelcomeMail : Constant.NewCustomerMail.notSendingNewCustomerMail; 

            //Call the method that sends the mails
            Console.WriteLine(sendNewCustomerMessage);           
            bool newCustomerMailSenderValidation = NewCustomerMail.WelcomMail();// Start to send mail.

            bool validateOrderrList = validateCustomerList == true ? oldCustomerListCount >= 1 : false; //true if list has customer else false
            int orderListCount = DataLayer.ListOrders().Count;
            string sendOldCustomerMessage = validateOrderrList == true ? Constant.OldCustomerMail.sendingComeBackMail : Constant.OldCustomerMail.notSenndingComeBackMail;
            Console.WriteLine(sendOldCustomerMessage);

            //Oldcustomer is used to validate so we can keep track on oldCustomerlist and orderList.  
            bool oldCustomerMailSenderValidation = validateOrderrList == true ? oldCustomerListCount >= 1 : false;


            oldCustomerMailSenderValidation = DataHelper.DaysOfWeek() ? OldCustomerMail.mailToOldCustomer(OldCustomerMail.GetCustomerList(), OldCustomerMail.GetOrderList()) : false;

            //We send out message on the console to inform about the message that are sent
            string newCustomerMessage = newCustomerMailSenderValidation == true ? Constant.NewCustomerMail.newCustomerMailSent : Constant.NewCustomerMail.newCustomerMailNotSent;
            string oldCustomerMessage = oldCustomerMailSenderValidation == true ? Constant.OldCustomerMail.oldCustomerMailSent: Constant.OldCustomerMail.oldCustomerMailNotsent;

          Console.WriteLine(newCustomerMessage +" \n" + oldCustomerMessage);
          Console.ReadKey();
        }
    }
}