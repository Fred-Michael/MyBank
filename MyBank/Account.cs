using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyBank
{
    public enum AccountType
    {
        Savings,
        Current
    }
    public class Account
    {
        public string AccountNumber { get; }
        public Customers Owner { get; }
        public AccountType TypeOfAccount { get; }
        public DateTime AccountCreationDate { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in transactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        // An account number generator for account creation
        private static int AccountNumberGenerator = 1010;

        // Holds the list of transactions done by a client
        private List<Transaction> transactions = new List<Transaction>();

        public Account(Customers nameOfCustomer, int initialBalance, AccountType accountType)
        {
            Owner = nameOfCustomer;
            if (accountType == AccountType.Savings && initialBalance >= 100) TypeOfAccount = AccountType.Savings;

            else if (accountType == AccountType.Current && initialBalance >= 1000) TypeOfAccount = AccountType.Current;

            else throw new InvalidDataException("Account type must either be 'Savings' with an initial balance of 100 OR 'Current' with initial balance of 1000");

            AccountNumber = AccountNumberGenerator.ToString();
            AccountNumberGenerator++;
            AccountCreationDate = DateTime.Today;

            MakeDeposit(initialBalance, DateTime.Today, "First Initial Deposit!");
        }
        public void MakeDeposit(decimal amountToDeposit, DateTime date, string note)
        {
            if (amountToDeposit <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amountToDeposit), "Deposit amount must be from 1 upwards");
            }
            var deposit = new Transaction(amountToDeposit, date, note);
            transactions.Add(deposit);
        }
        public void MakeWithdrawal(decimal amountToWithdraw, DateTime date, string note)
        {
            if (amountToWithdraw <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amountToWithdraw), "Insufficient balance. Balance can not go beyond 0");
            }
            if (Balance - amountToWithdraw <= 0)
            {
                throw new InvalidOperationException("Not enough money for this withdrawal");
            }
            var withdrawalChanges = new Transaction(-amountToWithdraw, date, note);
            transactions.Add(withdrawalChanges);
        }
        public string getBalance()
        {
            return ($"Dear customer, your account balance is: {Balance}");
        }
        public string listOfTransactions()
        {
            var statement = String.Empty;
            foreach (var item in transactions)
            {
                statement += $"Transaction details:\nAmount Transacted - ({item.Amount}), Reason - {item.Note}\n";
            }
            return statement;
        }
    }
}
