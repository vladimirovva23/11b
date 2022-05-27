using NUnit.Framework;
using BankAccount;

namespace BankAccount.Test
{
    [TestFixture]
    public class BankAccountTest
    {
        [Test]

        public void AccountInitializeWithPositiveValue()
        {
            BankAccount account = new BankAccount(2000m);

            Assert.AreEqual(2000m, account.Balance);
        }

        [Test]
        public void DepositShouldAddMoney()
        {
            BankAccount account = new BankAccount();

            account.Deposit(50);

            Assert.IsTrue(account.Balance == 50);
        }

        [Test]
        public void CreditShouldAddMoney()
        {
            BankAccount account = new BankAccount();

            account.Credit(50);

            Assert.IsTrue(account.Balance == 50);
        }
    
    
        [Test]
        public void IncreaseShouldAddMoney()
        {
            BankAccount account = new BankAccount();
            account.Deposit(100);

            account.Increase(10);

            Assert.IsTrue(account.Balance == 110);
        }
    
        [Test]
        public void BonusShouldAddMoney()
        {
            BankAccount account = new BankAccount();
            account.Deposit(1001);

            account.Bonus();

            Assert.IsTrue(account.Balance == 1101);
        }

        [Test]
        public void BonusShouldAddMoney1()
        {
            BankAccount account = new BankAccount();
            account.Deposit(2001);

            account.Bonus();

            Assert.IsTrue(account.Balance == 2201);
        }

        [Test]
        public void BonusShouldAddMoney2()
        {
            BankAccount account = new BankAccount();
            account.Deposit(3001);

            account.Bonus();

            Assert.IsTrue(account.Balance == 3301);
        }
    }
}