using System;
using System.Collections.Generic;

namespace EmailSenderProgram.MailTypes
{
    class OldCustomerMail
    {

        /// <summary>
        /// Get customer mocked list
        /// </summary>
        /// <returns>List<Customer></returns>
    public static List<Customer> GetCustomerList()
        {
            List<Customer> customerList = DataLayer.ListCustomers();
            return customerList;
        }

        /// <summary>
        /// Get order mocked list
        /// </summary>
        /// <returns>List<Order></returns>
    public static List<Order> GetOrderList()
        {
            List<Order> orderList = DataLayer.ListOrders();
            return orderList;
        }

        /// <summary>
        /// Validate that the list is not empty
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool validateCustomareListNotEmpty()
        {
            bool customerListValid = DataHelper.CheckListIfNull(GetCustomerList());
            return true;
        }

        /// <summary>
        /// Validate that the list is not empty
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool ValidateOrderListNotEmpty()
        {
            bool orderListValid = DataHelper.CheckListIfNull(GetOrderList());
            return true;
        }

        /// <summary>
        /// Check if customer has orders if he has he is not a new customer
        /// </summary>
        /// <param name="customerList"></param>
        /// <param name="orderList"></param>
        /// <returns>Boolean</returns>
        public static bool mailToOldCustomer(List<Customer> customerList, List<Order> orderList)
        {

            bool send = true;
            List<Customer> oldCustomerSendMailToList = new List<Customer>();
            
            foreach (Customer customer in customerList)
            {
                foreach (Order order in orderList)
                {
                    if (customer.Email == order.CustomerEmail)
                    {
                        send = false;
                        Console.WriteLine("Send Come back Deal mail to:" + customer.Email.Substring(0, customer.Email.LastIndexOf("@")));
                        var sender = new EmailSender(Constant.MailCredentials.userName, Constant.MailCredentials.password);
                        sender.SendMail(customer.Email, Constant.Mail.from, "Hi " + customer.Email.Substring(0, customer.Email.LastIndexOf(("@"))) +" " + Constant.OldCustomerMail.oldCustomerBody);
                    }
                }
            }

            //All mails are sent!Success!
            return send = true;
        }

    }
}
           

