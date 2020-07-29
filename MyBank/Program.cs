using System;
using System.Text;

namespace MyBank
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Bank");
            Console.WriteLine("Pls select a command to continue");
            var myownBank = new Bank();

            var hold = "";
            while (hold != "7")
            {
                Console.WriteLine("1. Login\n2. Create account\n3. Deposit\n4. Withdraw\n5. Transfer\n6. View transaction details\n7. Logout");
                var response = Console.ReadLine();

                if (response == "1")
                {
                    Console.WriteLine("Enter your Fullname");
                    var Fname = Console.ReadLine();
                    Console.WriteLine("Enter your email");
                    var email = Console.ReadLine();
                    Console.WriteLine("Enter your password");
                    var password = Console.ReadLine();
                    
                    myownBank.Login(Fname, password, email);
                }

                if (response == "2")
                {
                    Console.WriteLine("Enter your Fullname");
                    var Fname = Console.ReadLine();                    
                    foreach (var item in myownBank.customers)
                    {
                        if (item.FullName == Fname)
                        {
                            break;
                        }
                    }

                    Console.WriteLine("Enter your minimum deposit");
                    var deposit = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your account type: Savings/Current");
                    var accountType = Console.ReadLine();
                }

                if (response == "3")
                {
                    Console.WriteLine("Not yet implemented");
                }
                if (response == "4")
                {
                    Console.WriteLine("Not yet implemented");
                }
                if (response == "5")
                {
                    Console.WriteLine("Not yet implemented");
                }
                if (response == "6")
                {
                    Console.WriteLine("Not yet implemented");
                }
                if (response == "7")
                {
                    Console.WriteLine("\nThank you for banking with us");
                    break;
                }
            }
        }
    }
}
