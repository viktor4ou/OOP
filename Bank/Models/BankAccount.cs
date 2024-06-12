using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Exceptions;

namespace Bank.Models
{
    public class BankAccount
    {
        public BankAccount(int accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }
        public int AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

       public void Deposit(decimal amount)
        {

            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (Balance < amount)
            {
                throw new InsufficientBalanceException(ExeptionMessages.InsufficientBalance);
            }
            Balance -= amount;
        }
    }
}
