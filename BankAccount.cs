using System;
using System.Collections.Generic;

namespace firstdot
{
    public class BankAccount
    {
        public string Userid { get;}
        public string Owner { get; set;}
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return Balance;
            }
        }

        private static int accountnumber_base = 160 ;

        public BankAccount(string name, decimal InitialBalance)
        {
            this.Userid = accountnumber_base.ToString();
            accountnumber_base++;
        
            this.Owner = name;
            MakeDeposit(InitialBalance, DateTime.Now, "Initial balance");
        }
        private List<Transaction> allTransactions =  new List<Transaction>();
        
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }
        public void MakeWithDrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposit must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not Sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction( -amount, date, note);
            allTransactions.Add(withdrawal);
        }

    }
}