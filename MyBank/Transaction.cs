using System;
using System.Collections.Generic;
using System.Text;

namespace MyBank
{
    public class Transaction
    {
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Note = note;
        }
    }
    
}
