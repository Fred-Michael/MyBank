using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank
{
    public class Customers
    {
        public string FullName { get; set; }
        public string CustomerEmail { get; set; }
        public int CustomerID { get; set; }

        private static int CustomerIDGenerator = 1;

        public Customers(string customerName, string customerEmail)
        {
            FullName = customerName;
            CustomerEmail = customerEmail;
            CustomerID = CustomerIDGenerator;
            CustomerIDGenerator++;
        }
    }
}
