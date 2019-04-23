using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderProgram
{
    class DataHelper
    {
        /// <summary>
        /// Use to filter list to check if they are empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>Bool</returns>
        public static bool CheckListIfNull<T>(IEnumerable<T> source)
        {
            if (source != null && source.Any())
                return true;
            else
                return false;
        }

        public static int OldCustomersInList(List<Customer> customerList, List<Order> orderList)
        {
            int count = 0;
            foreach (Customer customer in customerList)
            {
                foreach (Order order in orderList)
                {
                    if (customer.Email == order.CustomerEmail)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public static int NewCustomerCount(List<Customer> customerList)
        {
            int count = 0;
            foreach (Customer customer in customerList)
            {
                    if (customer.CreatedDateTime >= DateTime.Now.AddDays(-1))
                    {
                        count++;
                    }
            }

            return count;
        }

        /// <summary>
        /// Checks for sunday.
        /// </summary>
        /// <returns>Bool</returns>
        public static bool DaysOfWeek()
        {
            if (DateTime.Now.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                return true;
            }
            else
            {
                Console.WriteLine("No mails are sent for old customers becouse it's " + DateTime.Now.DayOfWeek);
                return false;

            }
        }

    }    
}

