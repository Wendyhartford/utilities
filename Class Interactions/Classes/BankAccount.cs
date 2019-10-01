using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This file will contain the definition of a bank account.Object Oriented programming organizes code by creating types in the form of classes. 
//These classes contain the code that represents a specific entity. The BankAccount class represents a bank account.
//The code implements specific operations through methods and properties.In this tutorial, the bank account supports this behavior:


//It has a 10-digit number that uniquely identifies the bank account.
//It has a string that stores the name or names of the owners.
//The balance can be retrieved.
//It accepts deposits.
//It accepts withdrawals.
//The initial balance must be positive.
//Withdrawals cannot result in a negative balance.

namespace Classes
{
    public class BankAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        // BalanceComputation
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }
       

        private static int accountNumberSeed = 1234567890;
         Constructor
        public BankAccount(string name, decimal initialBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        

         //TransactionDeclaration
        private List<Transaction> allTransactions = new List<Transaction>();
        

        // DepositAndWithdrawal
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
        

        //History
        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            report.AppendLine("Date\tAmount\tNote");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{item.Notes}");
            }

            return report.ToString();
        }
       
    }
}

