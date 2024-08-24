using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanckTransactionMSTest
{
    internal class BankAccount
    {
        private double _balance;
        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposite Amount must be positive .");
            }
            _balance += amount;
        }
        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Withdrawal Amount must be positive.");
            }
            if (amount > _balance)
            {
                throw new ArgumentException("Insufficient funds");
            }
            _balance -= amount;
        }
        public double GetBalance() { return _balance; }
        public void Transfer(BankAccount toAccount,double amount)
        {
            if(toAccount == null)
            {
                throw new ArgumentNullException(nameof(toAccount));
            }
            Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }
}

