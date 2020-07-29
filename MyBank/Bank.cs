using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyBank
{
    public class Bank
    {
        private bool isLoggedIn = false;
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Customers> customers = new List<Customers>();

        public List<Account> accounts = new List<Account>();
        public void Login(string name, string password, string email)
        {
            Name = name;
            Password = password;
            Email = email;
            if (Name.Length > 3 && Password.Length > 3 && Email.Contains(".com"))
            {
                isLoggedIn = true;
                var newCustomer = new Customers(name, email);
                customers.Add(newCustomer);
                Console.WriteLine("Login successful\n");
            }
            else throw new InvalidOperationException("Name and Password must be from 4 characters upwards AND use a valid email address");
        }
        public void getCustomers()
        {
            foreach (var item in customers)
            {
                Console.WriteLine($"Name: {item.FullName}, Email: {item.CustomerEmail}, ID: {item.CustomerID}");
            }
        }
    }
}