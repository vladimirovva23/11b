using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class BankAccount
    {
        public BankAccount(decimal amount = 0)
        {
            this.balance = amount;
        }


        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public void Deposit(decimal cash)
        {
            this.balance += cash;
        }
    
        public void Credit(decimal cash)
        {
            this.balance += cash;
        }
   
    
        public void Increase(decimal percent)
        {
            this.balance = balance + balance*percent / 100;
                //100 = 100 + 100*10/100
        }
   
        public void Bonus()
        {
            if (this.balance > 1000 && this.balance < 2000)
            {
                this.balance = this.balance + 100;
            }

            if (this.balance >= 2000 && this.balance <= 3000)

            {
                this.balance = this.balance + 200;
            }

            if (this.balance > 3000)
            {
                this.balance = this.balance + 300;
            }
        }
    }
}
